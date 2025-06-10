using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player; // Reference to the player object
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float speed = 5f; // Speed at which the object moves
    public bool flip = false; // Whether to flip the sprite for facing direction
    private bool isFollowing = true; // Whether the object should be following the player

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player 1");


        rb = GetComponent<Rigidbody2D>();


        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player is tagged as 'Player 1'.");
        }
    }

    void FixedUpdate()
    {

        if (isFollowing && player != null)
        {
            FollowPlayerMovement();
        }
        else
        {

            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }


    public void SetFollowState(bool shouldFollow)
    {
        isFollowing = shouldFollow;
    }

    public void FollowPlayerMovement()
    {

        Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);


        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    

    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
