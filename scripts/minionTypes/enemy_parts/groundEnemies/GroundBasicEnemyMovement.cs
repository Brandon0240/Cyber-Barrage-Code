using UnityEngine;

public class GroundBasicEnemyMovement : MonoBehaviour
{
    public float acceleration = 5f;  // How quickly the enemy accelerates
    public float deceleration = 8f;  // How quickly the enemy slows down
    public float maxSpeed = 5f;      // Maximum movement speed
    public float detectionRadius = 10f; // Detection radius for the player
    public float stopDistance = 0.5f;  // Stopping distance from the player
    public bool flip = false;         // Whether to flip the sprite when moving

    private Transform player;
    private Rigidbody2D rb;
    private float currentSpeed = 0f;  // The enemy's current speed

    private Animator animator; // Animator in Child
    public float speedThreshold = 0.5f;
    void Start()
    {

        animator = GetComponentInChildren<Animator>(); 
        // Find the player in the scene
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
            Debug.LogError("Rigidbody2D is missing from the enemy!");
        }

        else
        {
            rb.freezeRotation = true; 
        }
    }

    void Update()
    {
        /*
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && distanceToPlayer > stopDistance)
        {
            AccelerateTowardsPlayer();
        }
        else
        {
            Decelerate();
        }
        if (animator != null)
        {


            Debug.Log("Animator is here");

        }

        Debug.Log((Mathf.Abs(currentSpeed));
            bool isMoving = Mathf.Abs(currentSpeed) > speedThreshold;
            Debug.Log("isMoving: "+isMoving);
            animator.SetBool("IsMoving", isMoving);
        */
        

    }
    void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && distanceToPlayer > stopDistance)
        {
            AccelerateTowardsPlayer();
        }
        else
        {
            Decelerate();
        }
        if (animator != null)
        {


            
            bool isMoving = Mathf.Abs(rb.velocity.x) > speedThreshold;
            
            animator.SetBool("IsMoving", isMoving);
            animator.speed = isMoving ? Mathf.Clamp(Mathf.Abs(rb.velocity.x) / maxSpeed, 0.5f, 2f) : 1f;
        }
        
       
    }

    private void AccelerateTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

 
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);


        rb.velocity = new Vector2(direction.x * currentSpeed, rb.velocity.y);
        
    }

    private void Decelerate()
    {

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * currentSpeed, rb.velocity.y);
    }

    
}
