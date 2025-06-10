using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackOnPlayer : MonoBehaviour
{
    public float knockbackForceX = 5f; // Horizontal knockback strength
    public float knockbackForceY = 2f;// Vertical knockback strength
    public void ApplyKnockBack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player 1");

        if (player != null)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
 
                Vector2 direction = (player.transform.position - transform.position).normalized;


                Vector2 knockbackForce = new Vector2(-direction.x * knockbackForceX, knockbackForceY);
                rb.velocity = Vector2.zero; 
                rb.AddForce(knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
