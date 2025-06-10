using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnPlayer : MonoBehaviour
{
    private int damageAmount; // Amount of damage dealt to the player
    void Start()
    {
        EnemyStatSheet statSheet = FindObjectOfType<EnemyStatSheet>();
        if (statSheet != null)
        {

            EnemyStats basicEnemyStats = statSheet.GetEnemyStats("BasicEnemy");


            damageAmount = basicEnemyStats.damage;
        }
        else
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
        }
    }
    public void ApplyDamageToPlayer()
    {
        
     
        GameObject player = GameObject.FindGameObjectWithTag("Player 1");

        if (player != null)
        {
            HealthManagerPlayer healthManager = player.GetComponent<HealthManagerPlayer>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damageAmount);
            }
        }
    }
}
