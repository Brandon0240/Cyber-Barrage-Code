using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileMovement : MonoBehaviour
{
    public float speed = 10f;           // Speed of the projectile          
    public float lifetime = 5f;         // How long the projectile exists before being destroyed
    private Transform player;           // Player's transform
    private Rigidbody2D rb;             // Rigidbody2D for movement

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player 1' not found!");
            return;
        }


        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from the projectile object!");
            return;
        }


        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;

        Destroy(gameObject, lifetime);
    }
}
