using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject shotgunAmmoPrefab;
    public GameObject rifleAmmoPrefab;
    public GameObject heartPrefab;
    private float spreadAmount = 2f;

    public static DropManager Instance; 

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void FodderRandomDrop(Vector3 position)
    {
        int randomDrop = Random.Range(0, 3);

        GameObject dropPrefab = null;
        switch (randomDrop)
        {
            case 0:
                dropPrefab = shotgunAmmoPrefab;
                break;
            case 1:
                dropPrefab = rifleAmmoPrefab;
                break;
            case 2:
                dropPrefab = heartPrefab;
                break;
        }

        if (dropPrefab != null)
        {
            Instantiate(dropPrefab, GetRandomDropPosition(position), Quaternion.identity);
        }
    }

    public void DropLoot(string enemyTag, Vector3 position)
    {
        EnemyStatSheet statSheet = FindObjectOfType<EnemyStatSheet>();
        if (statSheet == null)
        {
            Debug.LogError("DropManager: EnemyStatSheet not found in scene!");
            return;
        }

        EnemyStats enemyStats = statSheet.GetEnemyStats(enemyTag);

        if (enemyStats.drops != null && enemyStats.drops.Length > 0)
        {
            foreach (DropItem drop in enemyStats.drops)
            {
                if (drop.itemPrefab == null) continue;

                float roll = Random.Range(0f, 100f); 
                if (roll <= drop.dropChance)
                {
                    for (int i = 0; i < drop.amount; i++) 
                    {
                        Instantiate(drop.itemPrefab, GetRandomDropPosition(position), Quaternion.identity);
                    }
                }
            }
        }
    }

    private Vector3 GetRandomDropPosition(Vector3 originalPosition)
    {
        float randomX = Random.Range(-spreadAmount, spreadAmount);
        float randomY = Random.Range(-spreadAmount, spreadAmount);
        return new Vector3(originalPosition.x + randomX, originalPosition.y + randomY, originalPosition.z);
    }
}
