using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMode : MonoBehaviour
{
    private Rigidbody2D rb;
    private List<MonoBehaviour> movementScripts = new List<MonoBehaviour>();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from the boss!");
        }
        EnterIdleMode();

     
    }





    private void EnterIdleMode()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero; 
            rb.angularVelocity = 0f;
        }
    }


    
}
