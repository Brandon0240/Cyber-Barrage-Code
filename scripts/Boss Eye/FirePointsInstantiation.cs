using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointsInstantiation : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void firePointsInstantiation()
    {
        if (animator != null)
        {

        }
        else
        {
            Debug.LogWarning("Animator not found on " + gameObject.name);
        }

        foreach (Transform firePoint in firePoints)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ShooterTag bulletScript = bulletInstance.GetComponent<ShooterTag>();

            if (bulletScript != null)
            {
                bulletScript.SetShooterTag(gameObject.tag);
            }
            else
            {
                Debug.Log("bulletScript == null");
            }
        }
    }
}
