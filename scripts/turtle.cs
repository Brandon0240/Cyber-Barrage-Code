using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour {
    public float speed = 5f;
    public bool left = true;
    public int hp = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Death();
		if (left)
        {
                transform.position = transform.position + (Vector3.left * Time.deltaTime *speed);
            
        }
        else 
        {
                transform.position = transform.position + (Vector3.right * Time.deltaTime * speed);
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemycollider" || collision.gameObject.tag == "tribeMelee")
        {
            left = !left;
        }
        if (collision.gameObject.tag == "VoidSpikes")
        {
            hp -= 1;

        }
        if (collision.gameObject.tag == "slice")
        {
            hp -= 1;


        }
    }
        void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
