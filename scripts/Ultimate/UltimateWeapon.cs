using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateWeapon : MonoBehaviour
{
    public Transform firePoint;  // The point where bullets and rockets are fired from
    public GameObject bulletPrefab;  // The bullet prefab
    public GameObject trackingRocketPrefab;  // The rocket prefab
    public float bulletSpeed = 20f;  // Speed of bullets
    public float fireRate = 0.2f;  // Fire rate for bullets
    public float rocketInterval = 1f;  // Interval between rocket launches

    private float nextBulletFireTime = 0f;
    private float nextRocketFireTime = 0f;

    void Update()
    {
        Aim();

        if (Time.time >= nextBulletFireTime)
        {
            FireBullet();
            nextBulletFireTime = Time.time + fireRate;
        }


        if (Time.time >= nextRocketFireTime)
        {
            FireRocket();
            nextRocketFireTime = Time.time + rocketInterval;
        }
    }

    void FireBullet()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
    void Aim()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 


        Vector3 direction = (mousePosition - transform.position).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1); 
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
    }
    void FireRocket()
    {
        
        Instantiate(trackingRocketPrefab, firePoint.position, firePoint.rotation);
    }
}
