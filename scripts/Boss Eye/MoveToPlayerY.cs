using UnityEngine;

public class MoveToPlayerY : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    public float acceleration = 5f;  // How quickly the boss speeds up
    public float deceleration = 5f;  // How quickly the boss slows down
    public float maxSpeed = 5f;      // Maximum movement speed

    private float currentSpeed = 0f; // Tracks current movement speed

    void Awake()
    {

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player 1' not found!");
        }

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from the boss object!");
        }
    }

    void FixedUpdate()
    {
        if (player == null || rb == null)
            return;

        float direction = Mathf.Sign(player.position.y - transform.position.y); 
        float distance = Mathf.Abs(player.position.y - transform.position.y);

        if (distance > 0.1f) 
        {

            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.fixedDeltaTime, maxSpeed);
        }
        else
        {

            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.fixedDeltaTime, 0);
        }

        rb.velocity = new Vector2(rb.velocity.x, direction * currentSpeed);
    }
}
