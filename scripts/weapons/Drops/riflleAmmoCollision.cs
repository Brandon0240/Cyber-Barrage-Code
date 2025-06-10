using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riflleAmmoCollision : MonoBehaviour
{
    int rifle_ammo_amount = 10;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player 1"))
        {
            AmmoManager ammoManager = other.GetComponent<AmmoManager>();
            if (ammoManager != null)
            {
                ammoManager.ReloadAmmo(rifle_ammo_amount, AmmoManager.AmmoType.Rifle);
            }
            Destroy(gameObject);
        }
    }
}
