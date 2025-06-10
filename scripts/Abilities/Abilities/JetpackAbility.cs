using System.Collections;
using UnityEngine;

public class JetpackAbility : Ability
{
    public float maxAcceleration = 10f; 
    public float accelerationRate = 1f; 
    private float currentAcceleration = 0f;
    private Rigidbody2D rb;
    private PlayerJump playerJump;
    private bool isActive = false;
    private float jetForce = 15f;
    void Start()
    {
        Transform playerTransform = transform.root;
        rb = playerTransform.GetComponent<Rigidbody2D>();
        playerJump = playerTransform.GetComponent<PlayerJump>();
        setNoCooldown(true);
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found! Ensure the Player object has a Rigidbody2D component.");
        }
    }

    void Update()
    {
        if (Input.GetKey(activationKey)&& playerJump.getdidFirstJump())
        {
            
            TryActivate();
        }
        
    }

    public override void Activate()
    {

        rb.velocity = new Vector2(rb.velocity.x, jetForce);
        //StartCoroutine(ApplyJetpackForce());

    }
    /*
    private IEnumerator ApplyJetpackForce()
    {
        while (isActive && !playerJump.getisGrounded())
        {
            //Debug.Log(currentAcceleration);
            currentAcceleration += accelerationRate * Time.deltaTime;
            currentAcceleration = Mathf.Min(currentAcceleration, maxAcceleration);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + currentAcceleration * Time.deltaTime);
            yield return null;
        }
    }
    */
    private IEnumerator ApplyJetpackForce()
    {
        while (isActive && !playerJump.getisGrounded())
        {
            Debug.Log("IEnumerator ApplyJetpackForce()");
            currentAcceleration += accelerationRate * Time.deltaTime;
            currentAcceleration = Mathf.Min(currentAcceleration, maxAcceleration);

            rb.AddForce(Vector2.up * currentAcceleration, ForceMode2D.Force);

            yield return null;
        }
        isActive = false;
    }

}
