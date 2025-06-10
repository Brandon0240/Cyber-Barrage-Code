using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTypeUpdate : MonoBehaviour
{
    private AmmoManager ammoManager;
    private GunName gunName; 
    void Start()
    {
        ammoManager = GetComponentInParent<AmmoManager>();
        gunName = GetComponent<GunName>(); 

        if (gunName == null)
        {
            Debug.LogError("GunName component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("Rifle"))
        {
            ammoManager.ammoType = AmmoManager.AmmoType.Rifle;
            
        }
        else if (gameObject.CompareTag("Shotgun"))
        {
            ammoManager.ammoType = AmmoManager.AmmoType.Shotgun;
        }

        if (gunName != null)
        {
            ammoManager.currentWeaponName = gunName.getName();
        }
    }
}