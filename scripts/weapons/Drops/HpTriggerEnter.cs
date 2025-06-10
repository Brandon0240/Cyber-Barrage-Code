using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTriggerEnter : MonoBehaviour
{
    int health_restored = 10;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player 1"))
        {
            HealthManagerPlayer healthManager = other.GetComponent<HealthManagerPlayer>();
            healthManager.gainHealth(health_restored);
            Destroy(gameObject);
        }
    }
}
