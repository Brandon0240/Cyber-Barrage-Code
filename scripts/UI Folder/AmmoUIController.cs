using UnityEngine;

public class AmmoUIController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject rifleAmmoBar;   // UI element for rifle ammo
    public GameObject shotgunAmmoBar; // UI element for shotgun ammo
    public GameObject UltimateMinigunBar;
    //public GameObject shotgunAmmoBar;
    [Header("Ammo Manager Reference")]
    public AmmoManager ammoManager; // Reference to AmmoManager in the scene

    void Start()
    {

        if (ammoManager == null)
        {
            ammoManager = FindObjectOfType<AmmoManager>();
            if (ammoManager == null)
            {
                Debug.LogError("AmmoManager not found in the scene!");
                return;
            }
        }

        UpdateAmmoUI();
    }

    void Update()
    {
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        if (ammoManager == null) return;


        rifleAmmoBar.SetActive(ammoManager.ammoType == AmmoManager.AmmoType.Rifle);
        shotgunAmmoBar.SetActive(ammoManager.ammoType == AmmoManager.AmmoType.Shotgun);
        UltimateMinigunBar.SetActive(ammoManager.ammoType == AmmoManager.AmmoType.Ultimate);
      
    }
}
