using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun_shell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particles;
    public float move;
    float timer;
    public float damage = 1;
    public GameObject khazix;
    public GameObject enemy;
    public bool locked;
    public bool right;
    public bool left;
    void Start()
    {
        timer = .4f;
        locked = false;
        //  shot();
    }

    // Update is called once per frame
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
    void shot()
    {

        Player playerScript = khazix.GetComponent<Player>();

        if (locked == false)
        {
            if (playerScript.getIsRight() == true)
            {

                right = true;
                locked = true;

                locked = true;
            }
            else if (playerScript.getIsRight() == false)
            {

                left = true;
                locked = true;

            }
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
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
