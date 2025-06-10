using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 15f;
    public float speedThreshold = 0.1f;

    private float currentSpeed = 0f;
    private float moveDirection = 0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator; // Animator in Child
    private PlayerJump playerJump; // Reference to Jump Script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>(); 
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; 

        playerJump = GetComponent<PlayerJump>(); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            spriteRenderer.flipX = false; 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            spriteRenderer.flipX = true; 
        }
        else
        {
            moveDirection = 0f; 
        }

        
       
        if (animator != null)
        {
          
        
            animator.SetBool("IsRunning", moveDirection != 0);

        }
    }

    void FixedUpdate()
    {
        float targetSpeed = moveDirection * maxSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        if (animator != null)
        {
            bool isMoving = Mathf.Abs(currentSpeed) > speedThreshold;
            animator.SetBool("IsRunning", isMoving);

        }
        
    }
}
