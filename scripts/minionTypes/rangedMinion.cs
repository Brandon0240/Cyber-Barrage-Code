using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class rangedMinion : MonoBehaviour
{


    public float Range;
    public Transform Target;
    public GameObject player;
    bool Detected = false;
    
    public Gun Gun;
    public GameObject RotationPoint;
    public bool isRight;
    Vector2 Direction;
    public Transform rayCenter;
    //
    public GameController GameController;



    /*
    public bool rotateLock = false;
    public int oneTime = 2;
    */
    public bool flip;
    public int hp = 5;
    private float speed = 3f;
    private float maxSpeed = 3f;

    public bool fireMode = false;
    // transform.Rotate(transform.localRotation.x, 180f, transform.localRotation.z);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        int layerMask = ~LayerMask.GetMask("IgnoreRaycast");

        RaycastHit2D rayInfo = Physics2D.Raycast(rayCenter.transform.position, Direction, Range);
        Vector3 scale = transform.localScale;

        Death();
        //if player is destroyed, return to the beginning of the update
        if (player == null)
        {
            return;
        }
        int l = 0;
        if (rayInfo)
        {
            if (!fireMode)
            {
                if (rayInfo.collider.gameObject.tag == "Enemy")
                {
                    UnityEngine.Debug.Log("enemy detected");
                }
                if (rayInfo.collider.gameObject.tag == "Player 1")
                {
                    if (Detected == false)
                    {
                        speed = 0;
                        Detected = true;
                        fireMode = true;

                    }
                }
            } else
            {
                //UnityEngine.Debug.Log("shoot");
                Gun.Shoot();
            }
           
        }
        else 
            {
                if (Detected == true)
                {
                    fireMode = false;
                    
                    speed = maxSpeed;
                    Detected = false;
                }
            }
        if (player.transform.position.x > transform.position.x)
        {
            Gun.rotate(isRight);
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime, y: 0, z: 0);
            isRight = false;
        }
        else
        {
            Gun.rotate(isRight);
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
            isRight = true;
        }
        transform.localScale = scale;






        /*
         
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player 1")
            {
                if (Target.position< )
                
            }
         
        }

         if (rayInfo)
        {
       
            if (rayInfo.collider.gameObject.tag == "Player 1")
            {
                UnityEngine.Debug.Log("player");
                speed = 0;


            }
            if (rayInfo.collider.gameObject.tag != "Player 1")
            {
                UnityEngine.Debug.Log("speed");
                speed = maxSpeed;


            }
          

       }
        */

    }

    //public DropManager dropManager;
    void Death()
    {
        if (hp <= 0)
        {
            GameController.addPoints(10);
            DropManager dropManager = FindObjectOfType<DropManager>();
            if (dropManager != null)
            {
                dropManager.FodderRandomDrop(transform.position);
            }
            else
            {
                UnityEngine.Debug.Log("(ammoDropManager == null");
            }
            Destroy(gameObject);
        }
    }
    public bool getIsRight()
    {
        UnityEngine.Debug.Log("get is right ");
        return isRight;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void rotationGun()//https://www.youtube.com/watch?v=dCtt6ri5Iag&list=LL&index=1&t=489s&ab_channel=TheGameGuy
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)RotationPoint.transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            
            if (rayInfo.collider.gameObject.tag == "Player 1")
            {
                if (Detected == false)
                {
                    Detected = true;

                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;

                }
            }
        }

        if (Detected)
        {
         //   Gun.transform.up = Direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "VoidSpikes")
        {
            hp -= 1;


        }
        if (collision.gameObject.tag == "slice")
        {
            hp -= 1;


        }
        if (collision.gameObject.tag == "missile")
        {
            hp -= 1;


        }

    }
}
/*
 * 
 *  if (transform.position.x < Player.transform.position.x)
        {
            if (oneTime == 2 && isRight == false) {
                oneTime = 1;
                    }
            UnityEngine.Debug.Log("right");
            isRight = true;
            if (oneTime == 1) {
                transform.Rotate(transform.localRotation.x, 0f, transform.localRotation.z);
                oneTime = 3;
            }
          
        }
        if (transform.position.x >= Player.transform.position.x)
        {
            if(oneTime == 3 && isRight == true)
            {
                oneTime = -1;
            }
            isRight = false;
            if (oneTime == -1)
            {
                transform.Rotate(transform.localRotation.x, 180f, transform.localRotation.z);
                oneTime = 2;
            }
                
        }
 */