using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateController : MonoBehaviour
{
    [Header("Ultimate Settings")]
    private int maxUltimateCharge = 100;  // The maximum ultimate charge
    private int ultimateChargeGainPerKill = 50;  // How much charge is gained per kill
    public float ultimateDuration = 5f;  // Duration of the ultimate ability
    public GameObject ultimateWeapon;  // The weapon used during the ultimate
    private KeyCode activateUltimateKey = KeyCode.T;  // The key to activate ultimate

    private int currentUltimateCharge = 0;  // Tracks current ultimate charge
    private bool isUltimateActive = false;  // Tracks if the ultimate is active

    public WeaponController weaponController;  // Reference to the WeaponController
    public UltimateBar ultimateBar;
    private AmmoManager ammoManager;
    void Start()
    {
        ammoManager = GetComponentInParent<AmmoManager>();
        if (ammoManager == null)
        {
            Debug.LogError("AmmoManager not found on parent object!");
        }
 
    }

    void Update()
    {
        //Debug.Log("currentUltimateCharge >= maxUltimateCharge: ");
        //  Debug.Log("maxUltimateCharge: " + maxUltimateCharge);
        //  Debug.Log("currentUltimateCharge: " + currentUltimateCharge);
        // Debug.Log("Input.GetKeyDown(activateUltimateKey): " + Input.GetKey(activateUltimateKey));


       

        ultimateBar.setUltimateCharge(currentUltimateCharge, maxUltimateCharge);
        if (currentUltimateCharge >= maxUltimateCharge && Input.GetKey(activateUltimateKey))
        {
            
            ActivateUltimate();
        }
        //Debug.Log("currentUltimateCharge: "+ currentUltimateCharge);
    }

    public void GainUltimateCharge()
    {
        
        if (!isUltimateActive)
        {
            currentUltimateCharge += ultimateChargeGainPerKill;
            currentUltimateCharge = Mathf.Clamp(currentUltimateCharge, 0, maxUltimateCharge);
        }
    }
    public UltimateDurationBar ultimateDurationBar;
    private void ActivateUltimate()
    {
        if (ammoManager == null || weaponController == null || ultimateWeapon == null)
        {
            Debug.LogError("Ultimate activation failed: Missing references!");
            return;
        }
        ultimateDurationBar.SetMaxDuration(ultimateDuration);

        ammoManager.ammoType = AmmoManager.AmmoType.Ultimate;

        isUltimateActive = true;
        currentUltimateCharge = 0;  
        weaponController.primaryWeapon.SetActive(false);
        weaponController.secondaryWeapon.SetActive(false);
        ultimateWeapon.SetActive(true);


        StartCoroutine(UltimateDuration());
    }
    

    private IEnumerator UltimateDuration()
    {
        float timeLeft = ultimateDuration;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            ultimateDurationBar.SetDuration(timeLeft);
            yield return null;
        }
 
        isUltimateActive = false;
        ultimateWeapon.SetActive(false);
        weaponController.SwitchToPrimary();  
    }

    public bool IsUltimateActive()
    {
        return isUltimateActive;
    }
}
