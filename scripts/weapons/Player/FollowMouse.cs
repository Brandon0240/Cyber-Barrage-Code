using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
    
    }
    void Update()
    {
        Aim();
    }

    private bool isFlipped = false;
    void Aim()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 


        Vector3 direction = (mousePosition - transform.position).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
     
        bool shouldFlip = (angle > 90 || angle < -90);
        if (shouldFlip && !isFlipped)
        {

            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y * -1, transform.localScale.z);
            isFlipped = true;
        }
        else if (!shouldFlip && isFlipped)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y * -1, transform.localScale.z);
            isFlipped = false;
        }
    }
}