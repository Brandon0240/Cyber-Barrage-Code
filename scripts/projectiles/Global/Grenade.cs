using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionRadius = 3f;
    public float explosionForce = 500f;
    public GameObject explosionEffect;
    private int damageAmount;
    private ProjectileStatSheet projectileStatSheet;
    private ShooterTag shooter;
    private UltimateController ultimateController;
    private Rigidbody2D rb; 

    void Start()
    {
        projectileStatSheet = FindObjectOfType<ProjectileStatSheet>();

        if (projectileStatSheet == null)
        {
            Debug.LogError("ProjectileStatSheet not found in the scene!");
            return;
        }

        ProjectileStats projectileStats = projectileStatSheet.GetProjectileStats(gameObject.tag);

        if (projectileStats != null)
        {
            damageAmount = projectileStats.damage;
        }
        else
        {
            Debug.LogError("Projectile stats not found for tag: " + gameObject.tag);
        }

        shooter = GetComponent<ShooterTag>();

        if (shooter == null)
        {
            Debug.LogError("Shooter not found in the scene!");
        }

        ultimateController = FindObjectOfType<UltimateController>();

        if (ultimateController == null)
        {
            Debug.LogError("UltimateController not found in the scene!");
        }

        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Explode()
    {
        StartCoroutine(ExplosionRoutine()); 
    }

    private IEnumerator ExplosionRoutine()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero; 
            rb.isKinematic = true; 
        }

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D obj in objects)
        {
            allCollisionLogic(obj.gameObject);
        }

        yield return new WaitForSeconds(2f); 

        Destroy(gameObject); 
    }

    private void allCollisionLogic(GameObject hitObject)
    {
        string shooterTag = shooter.getShooterTag();
        if (string.IsNullOrEmpty(shooterTag))
        {
            Debug.Log("shooterTag is EMPTY. Needs to be assigned.");
            return;
        }

        Debug.Log("ShooterTag: " + shooterTag);

        if (hitObject.CompareTag(shooterTag))
        {
            return;
        }

        if (!shooterTag.Equals("Player 1"))
        {
            if (hitObject.CompareTag("Player 1"))
            {
                HealthManagerPlayer healthManager = hitObject.GetComponent<HealthManagerPlayer>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(damageAmount);
                }
            }
        }
        else
        {
            HealthManagerEnemy enemyHealth = hitObject.GetComponent<HealthManagerEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                if (ultimateController != null)
                {
                    ultimateController.GainUltimateCharge();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;
        string shooterTag = shooter.getShooterTag();
        if (hitObject.CompareTag(shooterTag))
        {
            return;
        }
        Explode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;
        string shooterTag = shooter.getShooterTag();
        if (hitObject.CompareTag(shooterTag))
        {
            return;
        }
        Explode();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
