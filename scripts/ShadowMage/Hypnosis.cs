using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypnosis : MonoBehaviour
{

    private Player player;
    // Start is called before the first frame update
    public GameObject particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Mage")
        {

            GameObject particle = (GameObject)Instantiate(particles);
            particle.transform.position = gameObject.transform.position;
            Destroy(gameObject);


        }
        if (coll.gameObject.tag == "Player 1")
        {

            GameObject particle = (GameObject)Instantiate(particles);
            particle.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            player = GameObject.FindObjectOfType<Player>();
            //player.setSlow(.5f, 1f);

        }


        /*
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
         */
    }
}
