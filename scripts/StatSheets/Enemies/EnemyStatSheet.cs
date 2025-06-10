using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem
{
    public GameObject itemPrefab;  // The item to drop
    public int amount = 1;         // How many of this item to drop
    [Range(0f, 100f)] public float dropChance = 100f; // Drop chance percentage
}

public class EnemyStats
{
    public int health;
    public int damage;
    public float speed;
    public int points;
    public GameObject deathParticle;
    public DropItem[] drops;

    // item[name, number, chance], item[]
}

public class EnemyStatSheet : MonoBehaviour
{
    public GameObject shotgunAmmoPrefab;
    public GameObject rifleAmmoPrefab;
    public GameObject heartPrefab;

    private Dictionary<string, EnemyStats> enemyStats = new Dictionary<string, EnemyStats>();

    void Awake()
    {

        enemyStats["BossA"] = new EnemyStats
        {
            health = 100,
            damage = 50,
            speed = 3.5f,
            points = 1000,
            deathParticle = null,
            drops = new DropItem[]
            {
                new DropItem { itemPrefab = shotgunAmmoPrefab, amount = 2, dropChance = 100f },
                new DropItem { itemPrefab = rifleAmmoPrefab, amount = 2, dropChance = 100f }
            }
        };

        enemyStats["BasicEnemy"] = new EnemyStats
        {
            health = 50,
            damage = 20,
            speed = 5f,
            points = 200,
            deathParticle = null,
            drops = new DropItem[]
            {
                new DropItem { itemPrefab = heartPrefab, amount = 1, dropChance = 30f },
                new DropItem { itemPrefab = shotgunAmmoPrefab, amount = 1, dropChance = 30f }
            }
        };
        enemyStats["BasicRangedEnemy"] = new EnemyStats
        {
            health = 15,
            damage = 10,
            speed = 5f,
            points = 200,
            deathParticle = null,
            drops = new DropItem[]
            {
                new DropItem { itemPrefab = heartPrefab, amount = 1, dropChance = 100f },
              
            }
        };
        enemyStats["BasicFlyingEnemy"] = new EnemyStats
        {
            health = 20,
            damage = 10,
            speed = 5f,
            points = 200,
            deathParticle = null,
            drops = new DropItem[]
            {
                new DropItem { itemPrefab = shotgunAmmoPrefab, amount = 1, dropChance = 100f },
                new DropItem { itemPrefab = rifleAmmoPrefab, amount = 1, dropChance = 100f },
            }
        };
        
        /*
        enemyStats["EnemyBasicLaser"] = new EnemyStats
        {
            //health = 1,
            damage = 10,
            speed = 4f,
            //points = 500,
          //  deathParticle = null,
          //  drops = new DropItem[]
         //   {
          //      new DropItem { itemPrefab = rifleAmmoPrefab, amount = 3, dropChance = 90f },
         //       new DropItem { itemPrefab = heartPrefab, amount = 2, dropChance = 40f }
          //  }
        };
        
        enemyStats["BossALaser"] = new EnemyStats
        {
            //health = 1,
            damage = 75,
            speed = 4f,
            //points = 500,
            //  deathParticle = null,
            //  drops = new DropItem[]
            //   {
            //      new DropItem { itemPrefab = rifleAmmoPrefab, amount = 3, dropChance = 90f },
            //       new DropItem { itemPrefab = heartPrefab, amount = 2, dropChance = 40f }
            //  }
        };
        enemyStats["RifleBullet"] = new EnemyStats
        {
            //health = 1,
            damage = 25,
            speed = 4f,
            //points = 500,
            //  deathParticle = null,
            //  drops = new DropItem[]
            //   {
            //      new DropItem { itemPrefab = rifleAmmoPrefab, amount = 3, dropChance = 90f },
            //       new DropItem { itemPrefab = heartPrefab, amount = 2, dropChance = 40f }
            //  }
        };
        */
    }

    public EnemyStats GetEnemyStats(string enemyTag)
    {
        if (enemyStats.TryGetValue(enemyTag, out EnemyStats stats))
        {
            return stats;
        }

        Debug.LogWarning($"Tag '{enemyTag}' not found! Returning default stats.");
        return new EnemyStats { health = 100, damage = 5, speed = 3f, points = 100, deathParticle = null, drops = new DropItem[0] };
    }
    public string[] GetAllEnemyNames()
    {
        return new List<string>(enemyStats.Keys).ToArray();
    }
}