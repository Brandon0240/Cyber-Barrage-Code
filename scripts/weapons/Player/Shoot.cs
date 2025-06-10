using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] firePoints;
    // public Transform firePoint;
    public GameObject bulletPrefab;
    private float fireRate = 0.1f;
    private float nextFireTime = 0f;
    private AmmoManager ammoManager;
    private GunStatSheet gunStatSheet;
    private GunName gunName;

    private GunRecoil gunRecoil;

    public AudioSource fireAudioSource;
    void Start()
    {

        ammoManager = GetComponentInParent<AmmoManager>();
        gunStatSheet = FindObjectOfType<GunStatSheet>();
        gunName = GetComponent<GunName>();
        gunRecoil = GetComponent<GunRecoil>();
        if (gunName == null)
        {
            Debug.LogError("gunName null");
            return;
        }

        //  Debug.Log(gunName.getName());
        if (gunStatSheet != null)
        {
            GunStats gunStats = gunStatSheet.GetGunStats(gunName.getName()); // Get gun stats based on current ammo type
            fireRate = gunStats.fireRate; // Assign fire rate from GunStatSheet
            //Debug.Log(gameObject.tag + ": " + fireRate);
        }
        else
        {
            Debug.LogError("GunStatSheet not found in parent!");
        }

    }

    public void Fire()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && ammoManager.GetCurrentAmmo() > 0)
        {
            ammoManager.useAmmo();

            firePointsInstantiation();
            if (fireAudioSource != null)
            {
                fireAudioSource.Play();
            }
            if (gunRecoil != null)
            {
                gunRecoil.ApplyRecoil(); // Trigger recoil effect
            }
            nextFireTime = Time.time + fireRate;
        }
    }
    private void firePointsInstantiation()
    {
        if (transform.parent == null)
        {
            Debug.LogError(gameObject.name + " has no parent at runtime!");
        }
        else
        {
            //  Debug.Log(gameObject.name + " parent: " + transform.parent.name + " | Tag: " + transform.parent.tag);
        }
        foreach (Transform firePoint in firePoints)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            ShooterTag bulletScript = bulletInstance.GetComponent<ShooterTag>();

            if (bulletScript != null)
            {


                bulletScript.SetShooterTag(transform.parent.tag); // Assign the shooter's tag to the bullet
                                                                  // Debug.Log("transform.parent.tag: " + transform.parent.tag);
            }
            else
            {
                Debug.Log("bulletScript == null");
            }


        }
    }
    void Update()
    {
        Fire();

    }
}
