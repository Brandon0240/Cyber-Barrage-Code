using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle : MonoBehaviour
{
    public Transform firePoint;  // The point where the bullets will be fired from
    public GameObject bulletPrefab;  // The bullet prefab
    public float bulletSpeed = 10f;  // The speed of the bullet

    private float fireRate = 0.1f;  // Time between shots (in seconds)

    private float nextFireTime = 0f;  // Tracks when the player can fire next
    private AmmoManager ammoManager;
    void Start()
    {
        ammoManager = GetComponentInParent<AmmoManager>();
       
    }

    void Update()
    {
        ammoManager.ammoType = AmmoManager.AmmoType.Rifle;
        Aim();      
        Shoot();
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

    public void Shoot()
    {

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime&& ammoManager.GetCurrentAmmo()>0) 
        {

            ammoManager.useAmmo();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
        
    }
}
