using UnityEngine;
using System.Collections;

public class GrenadeAbility : Ability
{
    public float explosionRadius = 3f;
    public float explosionForce = 500f;
    public GameObject grenadePrefab;
    public GameObject explosionEffect;
    public float throwForce = 10f;
    public GameObject firePointPrefab; 
    private Transform firePoint; 
    private void Start()
    {
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
        ThrowGrenade();
    }

    private void ThrowGrenade()
    {
        if (grenadePrefab != null && firePoint != null)
        {
            GameObject grenade = Instantiate(grenadePrefab, firePoint.position, Quaternion.identity);
            ShooterTag bulletScript = grenade.GetComponent<ShooterTag>();

            if (bulletScript != null)
            {
                bulletScript.SetShooterTag(transform.parent.parent.tag); 
                Debug.Log("transform.parent.tag: " + transform.parent.parent.tag);
            }
            else
            {
                Debug.Log("bulletScript == null");
            }

            Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 throwDirection = ((Vector2)mousePosition - (Vector2)firePoint.position).normalized;
                rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
            }
        }
    }
}
