using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocketProjectile : MonoBehaviour
{
    private EnemyStatSheet enemyStatSheet; 
    private float acceleration = 20f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyStatSheet = FindObjectOfType<EnemyStatSheet>();
        if (enemyStatSheet == null)
        {
            Debug.LogError("EnemyStatSheet not found in the scene!");
            Destroy(gameObject);
            return;
        }
    }

    void FixedUpdate()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            rb.velocity += direction * acceleration * Time.fixedDeltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
   
    }

    GameObject FindNearestEnemy()
    {
        string[] enemyTags = enemyStatSheet.GetAllEnemyNames();
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
            if (enemies != null)
            {
                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnemy = enemy;
                    }
                }
            }
        }

        return nearestEnemy;
    }
  }
    

