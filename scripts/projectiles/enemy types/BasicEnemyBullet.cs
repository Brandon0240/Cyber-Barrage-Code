
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject particles;
    public float move;
    float timer;
    public float damage = 1;
    public GameObject objectFiredFrom;
    public GameObject enemy;
    public bool locked;
    private bool right = false;
    private bool left = false;
    private bool once = true;

    public float speed2 = 20f;
    public Rigidbody2D rb; 
    //rangedMinion objectScript = objectFiredFrom.GetComponent<rangedMinion>();
    void Start()
    {
        timer = .7f;
        //locked = false;
        rb.velocity = transform.right * speed2;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (once)
        {
            shot();
            once = false;
        }
        speed();
        */
        selfDestruct();
        
    }
    void speed()
    {
        // transform.Translate(Vector3.right * move * Time.deltaTime);
        // timer = timer - Time.deltaTime;
        
         if (right)
         {
             Debug.Log("RIGHT IS TRUE ");
             transform.Translate(Vector3.right * move * Time.deltaTime);

             timer = timer - Time.deltaTime;

         }
         else if (left )
         {
             Debug.Log("LEFT IS TRUE ");
             transform.Translate(Vector3.left * move * Time.deltaTime);

             timer = timer - Time.deltaTime;
         }
         
        
    }
    void selfDestruct()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void shot()
    {

        rangedMinion objectScript = objectFiredFrom.GetComponent<rangedMinion>();


        if (objectScript.getIsRight() == true)
            {

            right = true;
           // left = false;
            UnityEngine.Debug.Log("right");


        }
        else if (objectScript.getIsRight() == false)
            {

                left = true;
          //   right = false;
            UnityEngine.Debug.Log("left");
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player 1")
        {

            GameObject particle = (GameObject)Instantiate(particles);
            particle.transform.position = gameObject.transform.position;
            Destroy(gameObject);

        }
        if (coll.gameObject.tag == "Ground")
        {

            GameObject particle = (GameObject)Instantiate(particles);
            particle.transform.position = gameObject.transform.position;
            Destroy(gameObject);

        }
      

    }
}
