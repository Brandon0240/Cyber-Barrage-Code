using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool isRight;
    public float speed = 6f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    public bool isGrounded;
    public MageHealthPanel health;// health panel
    public Player bug;//khazix prefab
    public Transform firepoint;

    private float LeapForce = 10f;//jump ability S key
    private float RightForce = 6f;
    //   private bool LeapBool = true;

    public GameObject ShadowBall; // ability one keycode7
    public float VoidSpikeCooldown;
    public int vsAmmo = 1;
    public float vsTimer = 0;
    private float vsCD = 2f;
    public bool vsLock = true;




    public GameObject Hypnosis; // ability one keycode9
    public float HypnosisCooldown;
    public int hAmmo = 1;
    public float hTimer = 0;
    private float hCD = 4f;
    public bool hLock = true;




    // damage for each ability
    public int shadowball = 2;
    public int slow = 3;


    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Abilities();
        Movement();
    }
    //click num lock if key code doesn't work
    void Movement()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.position = transform.position + Vector3.right * Time.deltaTime * speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isRight = true;

        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.position = transform.position + Vector3.left * Time.deltaTime * speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            isRight = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) && (isGrounded))
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        }

    }
    void Abilities()
    {

    }


    //return variables
    public int getShadowBallDps()
    {
        return shadowball;

    }
    public int getSlowDps()

    {
      return slow;
    }
}