using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slice : MonoBehaviour
{
    public GameObject particles;
    public float move;
    float timer;
    public float damage = 1;
    public GameObject khazix;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
       
        timer = .25f;
    }

    // Update is called once per frame
    void Update()
    {
        selfDestruct();

    }
    void selfDestruct()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
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

    }
}
