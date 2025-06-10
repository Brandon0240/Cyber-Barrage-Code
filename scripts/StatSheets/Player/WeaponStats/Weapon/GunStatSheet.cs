using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunStats
{
    public float fireRate;
    public GameObject fireParticles;
    public int ammo;
    public int ammoConsumed;
}

public class GunStatSheet : MonoBehaviour
{
    public GameObject muzzleFlashPrefab;

    private Dictionary<string, GunStats> gunStats = new Dictionary<string, GunStats>();

    void Awake()
    {
        gunStats["Rifle"] = new GunStats 
        {
            fireRate = 0.1f,
            fireParticles = muzzleFlashPrefab,
            ammo = 40
        };
        gunStats["Shotgun"] = new GunStats
        {
            fireRate = 0.1f,
            fireParticles = muzzleFlashPrefab,
            ammo = 10
        };
        gunStats["BasicRifle"] = new GunStats
        {
            fireRate = .2f,
            fireParticles = muzzleFlashPrefab,
            ammoConsumed = 1
        };
        gunStats["BasicShotgun"] = new GunStats
        {
            fireRate = 1f,
            fireParticles = muzzleFlashPrefab,
            ammoConsumed = 1
        };
        gunStats["UltimateMinigun"] = new GunStats
        {
            fireRate = .05f,
            fireParticles = muzzleFlashPrefab,
            ammoConsumed = 1
        };




    }

    public GunStats GetGunStats(string gunType)
    {
        if (gunStats.TryGetValue(gunType, out GunStats stats))
        {
            return stats;
        }

        Debug.LogWarning($"Gun type '{gunType}' not found! Returning default stats.");
        return new GunStats { fireRate = 0.2f, fireParticles = null, ammo = 30 };
    }
}