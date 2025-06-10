using UnityEngine;

public class FireMode : MonoBehaviour
{
    public GameObject projectilePrefab;   // Reference to the projectile prefab
    public Transform firePoint;           // The position from where the projectile will be fired
    public float fireCooldown = 1f;       // Cooldown time between each fire (in seconds)

    private float lastFireTime = 0f;      // Tracks the time since the last fire
    private FirePointsInstantiation firePointsScript;


    void Start()
    {
        
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogError("ProjectilePrefab or FirePoint is not assigned!");
        }
        firePointsScript = GetComponent<FirePointsInstantiation>(); 

        if (firePointsScript == null)
        {
            Debug.LogError("FirePointsInstantiation script not found on " + gameObject.name);
        }
    }

    void Update()
    {
       
        FireProjectile();
        
    }

    void FireProjectile()
    {

        if (Time.time - lastFireTime >= fireCooldown)
        {

            firePointsScript.firePointsInstantiation();

            lastFireTime = Time.time;
        }
    }
}
