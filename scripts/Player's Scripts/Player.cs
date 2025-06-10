using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerId = 0; // Prevents abilities from being able to hit the main player because of how it is a multiplayer game
    public StatSheet StatSheet;

    public int maxHealth = 100;
    public int currentHealth;
    public GameController GameController;
    public HealthBar healthBar;
    public AmmoBar ammoBar;

    private float speed = 18f;
    private float jumpForce = 14f;
    private Rigidbody2D rb;
    public bool isGrounded;
    public HealthPanel health;
    public GameObject winPanel;
    public GameObject losePanel;

    private bool isSlowed = false;
    private float slowTime = 0f;
    private float slowed = 1f;

    public bool isRight;

    public GameObject VoidSpike; // Projectile space key
    public float VoidSpikeCooldown;
    private int vsAmmo = 1;
    private float vsTimer = 0;
    private float vsCD = .35f;
    public bool vsLock = true;
    public int voidSpikesDps = 3;
    private int maxMag = 20; // Ammo UI to function
    private int currentMag = 20; // Ammo UI to function
    private float magTimer = 0;
    private float reloadTime = 2f; // Reload time for the voidspike

    public GameObject slice; // Melee Q key
    public float sliceCooldown;
    public int sAmmo = 1;
    public float sTimer = 0;
    private float sCD = 2f;
    public bool sLock = true;
    public Transform melee;
    public int sliceDps = 2; // Change variable to change stat

    private float LeapForce = 10f; // Jump ability S key
    private float RightForce = 6f;
    private bool LeapBool = true;
    private bool JumpBool = true;
    public int lAmmo = 1;
    public float lTimer = 0;
    private float lCD = 5f;
    public bool lLock = true;

    public bool defense; // Defense
    public spritechange spr;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    private HealthManagerPlayer healthManager;

    void Start()
    {
        healthManager = GetComponent<HealthManagerPlayer>();
        isRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (KBCounter <= 0)
        {
            /*
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + Vector3.right * Time.deltaTime * speed * slowed;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                isRight = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + Vector3.left * Time.deltaTime * speed * slowed;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                isRight = false;
            }
            */
        }
        else
        {
            if (KnockFromRight)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            else
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }

        if (!isSlowed)
        {
            /*
            if (Input.GetKeyDown(KeyCode.W) && isGrounded && LeapBool)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                JumpBool = false;
            }
            */
        }
    }

    public bool getIsRight()
    {
        return isRight;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            LeapBool = true;
            JumpBool = true;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            healthManager.TakeDamage(StatSheet.getMinion());
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("healthpack"))
        {
            health.GainLife();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("endingdoor"))
        {
            winPanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("basicEnemybullet"))
        {
            healthManager.TakeDamage(StatSheet.getMinion());
        }
    }
}
