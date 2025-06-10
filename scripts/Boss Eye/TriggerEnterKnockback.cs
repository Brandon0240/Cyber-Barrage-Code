using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;  
    private int damage = 10;
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player 1"))
        {

            HealthManagerPlayer healthManager = collider.GetComponent<HealthManagerPlayer>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage);  
            }

            


            ApplyKnockback(collider);

        }
    }
    private void ApplyKnockback(Collider2D playerCollider)
    {

        Vector2 knockbackDirection = (playerCollider.transform.position - transform.position).normalized;


        Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.velocity = knockbackDirection * knockbackForce;
        }
    }

}
