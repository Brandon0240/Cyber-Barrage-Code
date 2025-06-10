using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public GameObject particles;
    public float move;
    float timer;
    public float damage = 1;
 
    
    void Start()
    {
        timer = 2f;
     
       
    }
    void Update()
    {

        speed();
        selfDestruct();
    }
    void speed()
    {
        transform.Translate(Vector3.right * move * Time.deltaTime);
        timer = timer - Time.deltaTime;
    }
        void selfDestruct()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
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
        if (coll.gameObject.tag == "Mage")
        {

            GameObject particle = (GameObject)Instantiate(particles);
            particle.transform.position = gameObject.transform.position;
            Destroy(gameObject);

        }

    }
}
