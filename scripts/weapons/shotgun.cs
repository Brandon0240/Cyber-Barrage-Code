using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    
    public Transform[] firePoints;

    public GameObject bulletPrefab;  // The bullet prefab
    public float bulletSpeed = 10;  // The speed of the bullet

    public float fireRate = 0.5f;  // Time between shots (in seconds)

    private float nextFireTime = 0f;  // Tracks when the player can fire next
    // Start is called before the first frame update
    private AmmoManager ammoManager;
    void Start()
    {
        ammoManager = GetComponentInParent<AmmoManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoManager.ammoType = AmmoManager.AmmoType.Shotgun;
        Aim();       
        Shoot();
            
    }
    private bool isFlipped = false;
    void Aim()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 


        Vector3 direction = (mousePosition - transform.position).normalized;

  
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        /*
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1); // Flip on Y-axis and X
            //transform.rotation = Quaternion.Euler(0f, 180f, -angle);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Default scale
           // transform.rotation = Quaternion.Euler(0f, 0f, angle); // Normal rotation
        }
        */
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
    public void Shoot()
    {
 
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && ammoManager.GetCurrentAmmo() > 0) 
        {

            ammoManager.useAmmo();
            foreach (Transform firePoint in firePoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            nextFireTime = Time.time + fireRate;
        }
    }
}
