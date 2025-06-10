using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
{
    public Transform firePoint;  // The point where the bullets will be fired from
    public GameObject bulletPrefab;  // The bullet prefab
    public float bulletSpeed = 10;  // The speed of the bullet

    public float fireRate = 0.5f;  // Time between shots (in seconds)

    private float nextFireTime = 0f;  // Tracks when the player can fire next
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) 
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Aim()
    {
     
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

       
        Vector3 direction = (mousePosition - transform.position).normalized;

    
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void Shoot()
    {
   
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        /*
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
        */
    }
}
