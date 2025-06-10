using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class minionSpawner : MonoBehaviour
{
    public GameObject minion;
    private int wave = 1;
    private int durationBetween = 1000;
    private float time = 0;
    private bool stopper = false;
    void Start()
    {
        //Instantiate(minion, transform.position, transform.rotation);
    }


    void Update()
    {
        //Instantiate(minion, new Vector3(0, 0, 0), Quaternion.identity);
        if (wave == 1&&!stopper)
        {
            StartCoroutine(wave1(2));
            StartCoroutine(downTime(20));
            stopper = true;
        }
        else if (wave == 2 && !stopper)
        {
            
            StartCoroutine(wave2(3));
            StartCoroutine(downTime(20));
            stopper = true;
        }
        
    }
  
    private IEnumerator wave1(int duration)
    {
        Instantiate(minion, transform.position, transform.rotation);
        yield return new WaitForSeconds(duration);
        Instantiate(minion, transform.position, transform.rotation);
        yield return new WaitForSeconds(duration);
        Instantiate(minion, transform.position, transform.rotation);
        stopper = true;
    }
    private IEnumerator wave2(int duration)
    {
        Instantiate(minion, transform.position, transform.rotation);
        yield return new WaitForSeconds(duration);
        Instantiate(minion, transform.position, transform.rotation);
    }
    private IEnumerator downTime(int duration)
    {
        yield return new WaitForSeconds(duration);
        wave +=1;
        stopper = false;

    }

}
