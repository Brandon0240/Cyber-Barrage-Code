using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTransformTracking : MonoBehaviour
{
    public float pullRadius = 5f;    // Radius within which the ammo starts pulling towards the player
    private float pullForce = 10f;      // Force used to pull the ammo towards the player     // Amount of ammo to refill when collected
    public Vector2 pullCenterOffset = Vector2.zero; // Allow manual center position adjustment in the Editor

    private Rigidbody2D rb;
    private GameObject player;
    private ShooterTag shooter;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player 1");
        shooter = GetComponent<ShooterTag>();

        if (shooter == null)
        {
            Debug.LogError("Shooter not found in the scene!");
        }


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
    private bool targetFound = false;
    private GameObject target;
    void FixedUpdate()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (Vector3)pullCenterOffset, pullRadius);
        if (!targetFound || target == null)
        {
            foreach (Collider2D collider in colliders)
            {

                allCollisionLogic(collider.gameObject);

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

          
        }
        if (target != null)
        {
            Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, trackingSpeed * Time.deltaTime);
        }
    }
    private void allCollisionLogic(GameObject hitObject)
    {
        string shooterTag = shooter.getShooterTag();
        if (string.IsNullOrEmpty(shooterTag))
        {
            Debug.Log("shooterTag is EMPTY. Needs to be assigned.");
            return;
        }

        Debug.Log("ShooterTag: " + shooterTag);

        if (hitObject.CompareTag(shooterTag))
        {
            return;
        }

        if (!shooterTag.Equals("Player 1"))
        {
            if (hitObject.CompareTag("Player 1"))
            {

                target = hitObject;
            }
        }
        else
        {
           

            target = hitObject;
            
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3)pullCenterOffset, pullRadius); // Use the offset position
    }
}
