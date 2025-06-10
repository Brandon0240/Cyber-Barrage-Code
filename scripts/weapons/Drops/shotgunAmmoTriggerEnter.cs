using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunAmmoTriggerEnter : MonoBehaviour
{
    int shotgun_ammo_amount = 10;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player 1"))
        {
            AmmoManager ammoManager = other.GetComponent<AmmoManager>();
            if (ammoManager != null)
            {
                ammoManager.ReloadAmmo(shotgun_ammo_amount, AmmoManager.AmmoType.Shotgun);
            }
            Destroy(gameObject);
        }
    }
}
