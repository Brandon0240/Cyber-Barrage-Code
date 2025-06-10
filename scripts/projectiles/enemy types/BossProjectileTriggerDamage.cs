using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileTriggerDamage : MonoBehaviour
{
    private int damageAmount;
    private EnemyStatSheet statSheet;
    void Start()
    {
        statSheet = FindObjectOfType<EnemyStatSheet>();
        if (statSheet != null)
        {

            EnemyStats basicEnemyStats = statSheet.GetEnemyStats(gameObject.tag);


            damageAmount = basicEnemyStats.damage;
            Debug.Log("damageAmount: "+ damageAmount);
        }
        else
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player 1"))
        {

            HealthManagerPlayer healthManager = collider.gameObject.GetComponent<HealthManagerPlayer>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damageAmount);
            }

  
            Destroy(gameObject);
        }
    }
}
