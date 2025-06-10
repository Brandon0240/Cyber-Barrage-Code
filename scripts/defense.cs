using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Removed();
    }

    void Removed()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
