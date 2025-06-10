using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRadiusPlayer : MonoBehaviour
{
    private float damageCooldown = 1f; 
    private float damageTimer = 0f; 
    public int damageAmount = 10; 

    private bool playerInRange = false; 
    void Start()
    {
  
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Ground"), false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player 1"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Player 1"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {

        if (playerInRange)
        {

            damageTimer += Time.deltaTime;

 
            if (damageTimer >= damageCooldown)
            {
                ApplyDamageToPlayer();
                damageTimer = 0f; 
            }
        }
    }

    private void ApplyDamageToPlayer()
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
