using UnityEngine;
using System.Collections;

public class Dash : Ability
{
    public float dashSpeed = 40f;
    public float dashDuration = 0.2f;
    public float collisionOffset = 1f; 
    private Rigidbody2D rb;
    private Camera mainCamera;
    private bool isDashing = false;
    private Vector2 dashDirection;

    private void Start()
    {
        abilityName = "Dash";
        activationKey = KeyCode.LeftShift;
        mainCamera = Camera.main;
        cooldownTime = 3;
        Transform playerTransform = transform.root;
        rb = playerTransform.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found! Ensure the Player object has a Rigidbody2D component.");
        }
    }
    private float dashForce = 50;
    public float speed = 100;
    public override void Activate()
    {


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        rb.velocity = direction * speed;

        // old dash code
        /*
        if (!isDashing && rb != null)
        {
            dashDirection = GetMouseDirection();
            if (dashDirection != Vector2.zero)
            {
                StartCoroutine(DashMovement());
            }
        }
        */
    }

    private Vector2 GetMouseDirection()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)mouseWorldPosition - rb.position).normalized;
        return direction;
    }

    private IEnumerator DashMovement()
    {
        isDashing = true;

  
        rb.isKinematic = true;
        rb.velocity = Vector2.zero; 

        RaycastHit2D hit = Physics2D.Raycast(rb.position, dashDirection, dashSpeed * dashDuration, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {

            rb.position = hit.point - (dashDirection * collisionOffset);
        }
        else
        {

            rb.position += dashDirection * dashSpeed * dashDuration;
        }

        yield return new WaitForSeconds(dashDuration);

        rb.isKinematic = false;
        rb.velocity = Vector2.zero; 
        isDashing = false;
    }
}
