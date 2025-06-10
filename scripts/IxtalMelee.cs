using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IxtalMelee : MonoBehaviour
{

    // Start is called before the first frame update
    public float speed = 5f;
    public bool left = true;
    public int hp = 5;
    void Start()
    {
        
    }

    void Update()
    {
        Death();
        if (left)
        {
            transform.position = transform.position + (Vector3.left * Time.deltaTime * speed);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.position = transform.position + (Vector3.right * Time.deltaTime * speed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tribeMeleeCollider" || collision.gameObject.tag == "enemy")
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
