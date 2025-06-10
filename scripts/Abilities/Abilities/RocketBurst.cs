using System.Collections;
using UnityEngine;

public class RocketBurst : Ability
{
    public GameObject homingRocketPrefab; 
    public Transform firePoint; 
    public int rocketsPerBurst = 3; 
    public float burstDelay = 0.2f; 
    private bool isFiring = false; 
    public GameObject firePointPrefab;
    private void Start()
    {
        abilityName = "Rocket Burst";
        activationKey = KeyCode.Q; 
        if (firePointPrefab != null)
        {
            GameObject firePointInstance = Instantiate(firePointPrefab, transform.position, Quaternion.identity);
            firePointInstance.transform.SetParent(transform); 
            firePoint = firePointInstance.transform;

       
            Transform highestParent = transform;
            while (highestParent.parent != null)
            {
                highestParent = highestParent.parent;
            }
            firePoint.SetParent(highestParent);
            firePoint.position = highestParent.position;
        }
    }

    public override void Activate()
    {
        if (!isFiring)
        {
            StartCoroutine(FireRocketBurst());
        }
    }

    private IEnumerator FireRocketBurst()
    {
        isFiring = true;

        for (int i = 0; i < rocketsPerBurst; i++)
        {
            GameObject rocketInstance = Instantiate(homingRocketPrefab, firePoint.position, firePoint.rotation);
            ShooterTag bulletScript = rocketInstance.GetComponent<ShooterTag>();

            if (bulletScript != null)
            {
                bulletScript.SetShooterTag(transform.root.tag); 
            }
            else
            {
                Debug.LogWarning("ShooterTag script not found on the rocket prefab!");
            }

            yield return new WaitForSeconds(burstDelay); 
        }

        isFiring = false;
    }
}
