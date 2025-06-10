using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public enum AmmoType { Rifle, Shotgun, Ultimate }

    public AmmoType ammoType;  // Ammo type for the current weapon
    public string currentWeaponName;
    private int rifleAmmo;  // Starting ammo count for rifle
    private int shotgunAmmo; // Starting ammo count for shotgun

    private rifle rifleScript;  // Reference to the rifle script
    private shotgun shotgunScript;  // Reference to the shotgun script
    public int maxRifleAmmo; // Maximum capacity for rifle ammo
    public int maxShotgunAmmo; // Maximum capacity for shotgun ammo
    public AmmoBar[] ammoBar;
    
    private GunStatSheet gunStatSheet;

    
    void Start()
    {
        gunStatSheet = FindObjectOfType<GunStatSheet>();
        if (gunStatSheet == null)
        {
            Debug.LogError("GunStatSheet not found in the scene!");
            return;
        }
        

        GunStats rifleStats = gunStatSheet.GetGunStats("Rifle");
        GunStats shotgunStats = gunStatSheet.GetGunStats("Shotgun");

        rifleAmmo = rifleStats.ammo;
        shotgunAmmo = shotgunStats.ammo;
        maxRifleAmmo = rifleStats.ammo;
        maxShotgunAmmo = shotgunStats.ammo;
        if (ammoBar.Length > 0)
        {
            ammoBar[0].SetMaxAmmo(maxShotgunAmmo); 
        }

        if (ammoBar.Length > 1)
        {
            ammoBar[1].SetMaxAmmo(maxRifleAmmo); 
        }
        rifleScript = GetComponentInChildren<rifle>();  
        shotgunScript = GetComponentInChildren<shotgun>();  
    }

    void Update()
    {
       // Debug.Log("shotgunAmmo: "+ shotgunAmmo);
      //  Debug.Log("rifleAmmo: " + rifleAmmo);
        //Debug.Log("Ammo Type: " + ammoType);
        ammoBar[0].SetAmmo(shotgunAmmo);
        ammoBar[1].SetAmmo(rifleAmmo);
    }

    public void useAmmo()
    {
        if (ammoType == AmmoType.Rifle)
        {
        
            rifleAmmo--;          //getGunName.ammoConsumed;
        }
        else if (ammoType == AmmoType.Shotgun)
        {
            
            shotgunAmmo--;

        }
        
    }



    public void ReloadAmmo(int amount, AmmoType type)
    {
        if (type == AmmoType.Rifle)
        {
            rifleAmmo = Mathf.Min(rifleAmmo + amount, maxRifleAmmo); 
        }
        else if (type == AmmoType.Shotgun)
        {
            shotgunAmmo = Mathf.Min(shotgunAmmo + amount, maxShotgunAmmo); 
        }
    }



    //infinite ammo during ult
    public int GetCurrentAmmo()
    {
        if (ammoType == AmmoType.Rifle)
        {
            return rifleAmmo;
        }
        else if (ammoType == AmmoType.Shotgun)
        {
            return shotgunAmmo;
        }
        else if(ammoType == AmmoType.Ultimate)
        {
            return 100;
        }
        return 0;
    }
}
