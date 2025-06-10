using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerPlayer : MonoBehaviour
{
    private int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();

    }
    void checkHealth()
    {
        if (currentHealth <= 0)
        {
            GameController.GameOver();

            //Destroy(gameObject);

        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        //Debug.Log("currentHealth: "+ currentHealth);
    }
    public void gainHealth(int health_gained)
    {
        currentHealth += health_gained;
        currentHealth = Mathf.Min(currentHealth + health_gained, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
