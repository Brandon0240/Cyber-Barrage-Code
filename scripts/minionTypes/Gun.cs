using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private float timer;
    private float duration = 1;
    private bool isRight = true;
    private FirePointsInstantiation firePointsScript;

    void Start()
    {
        timer = duration;
        firePointsScript = GetComponent<FirePointsInstantiation>(); 

        if (firePointsScript == null)
        {
            Debug.LogError("FirePointsInstantiation script not found on " + gameObject.name);
        }
    }

    void Update()
    {
      
      


    }
    public void Shoot()
    {
       
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            
            timer = 0;
        }
        //StartCoroutine(fire(5));
    }
    public void rotate(bool direction)//rotates the fire point depending which way the rangedminion is aiming
    {
        isRight = direction;
        if (isRight)
        {
            firePoint.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (!isRight)
        {
            firePoint.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }
    
    private IEnumerator fire(int duration)// shoot a bullet every duration time
    {
        // Instantiate(bullet, firePoint.position, firePoint.rotation);
        firePointsScript.firePointsInstantiation();
        yield return new WaitForSeconds(duration);
        
    }
    
   
}
