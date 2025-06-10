using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterGlobalProjectile : MonoBehaviour
{
    private int damageAmount;
    private ProjectileStatSheet projectileStatSheet;
    private ShooterTag shooter;
    private UltimateController ultimateController; 

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        allCollisionLogic(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        allCollisionLogic(collision.gameObject);
    }

    private void allCollisionLogic(GameObject hitObject)
    {
        string shooterTag = shooter.getShooterTag();
        //Debug.Log("shooterTag: "+ shooterTag);
        if(shooterTag == "")
        {
            Debug.Log("shooterTag is EMPTY. needs to be assigned ");
            return;
        }
     //   Debug.Log("hitObjectTag: " + hitObject.tag);
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
                Destroy(gameObject);
            }
        }
        else
        {
           
            HealthManagerEnemy enemyHealth = hitObject.GetComponent<HealthManagerEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
                Destroy(gameObject);

         
                if (ultimateController != null)
                {
                    ultimateController.GainUltimateCharge();
                }
            }
        }
    }
}