using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalBulletMovement : MonoBehaviour
{
    private float move;
    private float timer;


    void Start()
    {
        ProjectileStatSheet statSheet = FindObjectOfType<ProjectileStatSheet>();
        if (statSheet != null)
        {
            ProjectileStats stats = statSheet.GetProjectileStats(gameObject.tag);
            move = stats.speed;
            timer = stats.lifespan;
        }
        
    }

    void Update()
    {
        Speed();
        SelfDestruct();
    }
    void Speed()
    {
        transform.Translate(Vector3.right * move * Time.deltaTime);
        timer -= Time.deltaTime;
    }
    void SelfDestruct()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
