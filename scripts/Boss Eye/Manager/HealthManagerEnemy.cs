using UnityEngine;

public class HealthManagerEnemy : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth;
    private EnemyStatSheet statSheet;

    private void Start()
    {
        // Get the EnemyStatSheet from the scene
        statSheet = FindObjectOfType<EnemyStatSheet>();
        if (statSheet == null)
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
            return;
        }

        // Get max HP based on the enemy's tag
        //maxHealth = statSheet.GetMaxHealth(gameObject.tag);
        EnemyStats bossStats = statSheet.GetEnemyStats(gameObject.tag);
        maxHealth = bossStats.health;
        //maxHealth = statSheet.GetMaxHealth(gameObject.tag);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log($"{gameObject.tag} took {damage} damage! HP: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Debug.Log($"{gameObject.tag} has been defeated!");

        if (DropManager.Instance != null)
        {
            DropManager.Instance.DropLoot(gameObject.tag, transform.position);
        }
        else
        {
            Debug.LogError("DropManager instance not found!");
        }

        Destroy(gameObject);
    }
}
