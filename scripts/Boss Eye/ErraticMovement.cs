using System.Collections;
using UnityEngine;

public class ErraticMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float acceleration = 5f;   // How quickly it speeds up
    public float deceleration = 5f;   // How quickly it slows down
    public float maxSpeed = 5f;       // Maximum movement speed
    public float moveDuration = 1f;   // Time before changing direction
    public float idleDuration = 0.5f; // Time spent stationary before moving again

    private Vector2 targetDirection;
    private float currentSpeed = 0f;
    private Coroutine movementRoutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from the boss object!");
        }
    }

    void OnEnable()
    {
        movementRoutine = StartCoroutine(MovementRoutine());
    }

    void OnDisable()
    {
        if (movementRoutine != null)
        {
            StopCoroutine(movementRoutine);  
            movementRoutine = null;
        }
        rb.velocity = Vector2.zero; 
      //  Debug.Log("disableErraticMovement");
    }

    IEnumerator MovementRoutine()
    {
        while (true)
        {

            targetDirection = Random.insideUnitCircle.normalized;

            float moveTimer = 0f;
            while (moveTimer < moveDuration)
            {
                moveTimer += Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
                rb.velocity = targetDirection * currentSpeed;
                yield return null;
            }

            while (currentSpeed > 0)
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0);
                rb.velocity = targetDirection * currentSpeed;
                yield return null;
            }

   
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(idleDuration);
        }
    }
}
