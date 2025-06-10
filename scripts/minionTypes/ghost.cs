using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy
    public float knockbackForce = 5f; // Force applied during knockback
    public float knockbackDuration = 0.5f; // Duration of knockback effect
    public float detectionRadius = 15f; // Detection range for the player
    public float rotateSpeed = 200f; // Rotation speed
    public string playerTag = "Player"; // Tag used for the player
    public bool flip; // Controls sprite flipping
    public int hp = 5;

    private Rigidbody2D rb; // Reference to Rigidbody2D
    private Transform player; // Reference to the player transform
    private bool isKnockedBack = false; // Tracks if the ghost is in knockback state
    private float knockbackTimer = 0f; // Timer for knockback duration
    private GameController gameController; // Reference to GameController
    private Player pveplayer; // Reference to Player

    void Start()
    {
        objectFinder();
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Ensure the player has the correct tag.");
        }
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found! Make sure it exists in the scene.");
        }
    }

    void objectFinder()
    {
        gameController = FindObjectOfType<GameController>();
        pveplayer = FindObjectOfType<Player>();
    }

    void Update()
    {
        Death();

 
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false; 
                rb.velocity = Vector2.zero; 
            }
            return; 
        }

        if (player == null) return;


        Vector2 direction = (player.position - transform.position).normalized;

   
        rb.velocity = direction * speed;


        Vector3 scale = transform.localScale;
        if (direction.x > 0) 
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        else 
        {
            scale.x = -Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        transform.localScale = scale;
    }

    void ApplyKnockback(Vector3 collisionPosition)
    {
        
        Vector2 knockbackDirection = (transform.position - collisionPosition).normalized;

        
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

       
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "VoidSpikes")
        {
            hp -= 1;
  
        }
        else if (collision.gameObject.tag == "slice")
        {
            hp -= 1;
        }
        else if (collision.gameObject.tag == "missile")
        {
            hp -= 1;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player 1")
        {
           
            ApplyKnockback(collision.transform.position);
        }
    }

    void Death()
    {
        if (hp <= 0)
        {
            
            DropManager dropManager = FindObjectOfType<DropManager>();
            if (dropManager != null)
            {
                dropManager.FodderRandomDrop(transform.position);
            }
            else
            {
                UnityEngine.Debug.Log("(ammoDropManager == null");
            }
            gameController.addPoints(10);
            Destroy(gameObject);
        }
    }
}
