using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    private int bulletDamage = 10;
    private PlayerBulletStatSheet statSheet;

    private void Start()
    {
  
        statSheet = FindObjectOfType<PlayerBulletStatSheet>();
        if (statSheet == null)
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
            return;
        }


        bulletDamage = statSheet.GetBulletDamage(gameObject.tag);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        HealthManagerEnemy enemyHealth = collision.GetComponent<HealthManagerEnemy>();

        if (enemyHealth != null)
        {
   
            enemyHealth.TakeDamage(bulletDamage);

     
            Destroy(gameObject);
        }
    }
}
