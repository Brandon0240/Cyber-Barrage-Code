using System.Collections;
using UnityEngine;

public class DashToPlayer : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    public float acceleration = 20f;
    public float deceleration = 30f;
    public float maxSpeed = 15f;
    public float dashDuration = 1f;
    public float resetTime = 2f; 

    private Vector2 dashDirection;
    private float currentSpeed = 0f;
    private float dashTimer = 0f;
    private bool isDashing = false;
    private Coroutine dashCoroutine;

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
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnEnable()
    {
        if (player != null)
        {
            StartDash();
        }
    }

    void OnDisable()
    {
        if (dashCoroutine != null)
        {
            StopCoroutine(dashCoroutine); 
            dashCoroutine = null;
        }
        isDashing = false;
        rb.velocity = Vector2.zero;
        CancelInvoke(nameof(StartDash)); 
      //  Debug.Log("DashToPlayer Disabled");
    }

    void StartDash()
    {
        if (player != null)
        {
            dashDirection = (player.position - transform.position).normalized;
            isDashing = true;
            dashTimer = 0f;
            currentSpeed = 0f;
            LookAtPlayer();
            dashCoroutine = StartCoroutine(DashCoroutine());
        }
    }

    IEnumerator DashCoroutine()
    {
        while (dashTimer < dashDuration)
        {
            dashTimer += Time.deltaTime;

            if (dashTimer < dashDuration / 2)
            {
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
            }
            else
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0);
            }

            rb.velocity = dashDirection * currentSpeed;
            yield return null;
        }

        StopDash();
    }

    void StopDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
        LookAtPlayer();
        Invoke(nameof(StartDash), resetTime);

    }
    private float rotationSpeed = 250; 
    private Coroutine rotateCoroutine;

    void LookAtPlayer()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
        rotateCoroutine = StartCoroutine(RotateToPlayerCoroutine());
    }

    IEnumerator RotateToPlayerCoroutine()
    {
        while (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float currentAngle = transform.rotation.eulerAngles.z;

            float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);


            if (Mathf.Abs(angleDifference) < 1f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
                yield break;
            }

 
            float rotationStep = rotationSpeed * Time.deltaTime * Mathf.Sign(angleDifference);
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle + rotationStep);

            yield return null;
        }
    }


    /*
    void LookAtPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    */
}
