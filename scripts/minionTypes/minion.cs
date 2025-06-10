using System.Collections;
using System.Collections.Generic;

using System.Threading;
using UnityEngine;

public class minion : MonoBehaviour
{
    private Rigidbody2D rb;
    private float recoil = 20f;
   
    private float speed = 3f;
    public GameObject player;
    public Player pveplayer;
    public GameController GameController;
    public bool flip;
    private bool isRight;
    public int hp = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Death();


        if (player == null)
        {
            return;
        }

        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime, y: 0, z: 0);
            isRight = false;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
            isRight = true;
        }
        transform.localScale = scale;

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
            Debug.Log("collision.gameObject.tag == missile");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player 1")
        {
            HealthManagerPlayer healthManager = collision.gameObject.GetComponent<HealthManagerPlayer>();
            healthManager.TakeDamage(20);
            /*
            pveplayer.KBCounter = pveplayer.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                pveplayer.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                pveplayer.KnockFromRight = false;
            }
            */
        }
        
            
        



    }
    void Death()
    {
        if (hp <= 0)
        {
          
            DropManager dropManager = FindObjectOfType<DropManager>();
            if (dropManager != null)
            {
                dropManager.FodderRandomDrop(transform.position);
            }
            else
            {
                UnityEngine.Debug.Log("(ammoDropManager == null");
            }
            GameController.addPoints(10);
            Destroy(gameObject);
        }
    }
}


