using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullRadiusAmmoDrops : MonoBehaviour
{
    public float pullRadius = 5f;    // Radius within which the ammo starts pulling towards the player
    private float pullForce = 10f;      // Force used to pull the ammo towards the player     // Amount of ammo to refill when collected
    public Vector2 pullCenterOffset = Vector2.zero; // Allow manual center position adjustment in the Editor

    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player 1");

       

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player is tagged as 'Player 1'.");
        }
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on " + gameObject.name + ". Please add a Rigidbody2D.");
        }
    }
    private bool collided = false;
    public float trackingSpeed = 20f;
    void FixedUpdate()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (Vector3)pullCenterOffset, pullRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player 1"))
            {
                Vector2 direction = (collider.transform.position - transform.position).normalized;

     
                if (rb != null)
                {
                    rb.AddForce(direction * pullForce, ForceMode2D.Force);
                    collided = true;
                }
            }
        }
       
        if (collided)
        {
            Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, trackingSpeed * Time.deltaTime);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3)pullCenterOffset, pullRadius); 
    }
}
