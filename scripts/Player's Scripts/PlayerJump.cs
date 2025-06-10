using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [Tooltip("How much force to apply for the jump.")]
    public float jumpForce = 10f;

    [Header("Ground Check Settings")]
    [Tooltip("A transform positioned at the bottom of the player.")]
    public Transform groundCheck;
    [Tooltip("Radius of the circle to check if grounded.")]
    public float checkRadius = 0.2f;
    [Tooltip("Which layers count as ground.")]
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool didFirstJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded)
        {
            didFirstJump = false;
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            didFirstJump = true;
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
    public bool getisGrounded()
    {
        return isGrounded;
    }
    public bool getdidFirstJump()
    {
        return didFirstJump;
    }
}
