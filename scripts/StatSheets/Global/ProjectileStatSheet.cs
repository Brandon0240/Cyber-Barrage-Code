using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileStats
{
    public int damage;
    public float speed;
    public float lifespan;
    public GameObject impactEffect;
}

public class ProjectileStatSheet : MonoBehaviour
{
    public GameObject bulletImpactEffect;
    public GameObject laserImpactEffect;
    public GameObject rocketExplosionEffect;

    private Dictionary<string, ProjectileStats> projectileStats = new Dictionary<string, ProjectileStats>();

    void Awake()
    {
        projectileStats["BasicBullet"] = new ProjectileStats
        {
            damage = 10,
            speed = 20f,
            lifespan = 2f,
            impactEffect = bulletImpactEffect
        };

        projectileStats["Ultimate"] = new ProjectileStats
        {
            damage = 25,
            speed = 50f,
            lifespan = 1f,
            impactEffect = laserImpactEffect
        };

        projectileStats["missile"] = new ProjectileStats
        {
            damage = 10,
            speed = 15f,
            lifespan = 3f,
            impactEffect = rocketExplosionEffect
        };

        projectileStats["RifleBullet"] = new ProjectileStats
        {
            damage = 10,
            speed = 40,
            lifespan = 2.5f,
            impactEffect = bulletImpactEffect
        };
        projectileStats["EnemyBasicLaser"] = new ProjectileStats
        {
            damage = 10,
            speed = 20f,
            lifespan = 2.5f,
            impactEffect = bulletImpactEffect
        };
        projectileStats["BossALaser"] = new ProjectileStats
        {
            damage = 20,
            speed = 20f,
            lifespan = 5f,
            impactEffect = bulletImpactEffect
        };
        projectileStats["ShotgunShell"] = new ProjectileStats
        {
            damage = 20,
            speed = 80f,
            lifespan = .1f,
            impactEffect = bulletImpactEffect
        };
        projectileStats["MachineGunBullet"] = new ProjectileStats
        {
            damage = 10,
            speed = 80f,
            lifespan = .5f,
            impactEffect = bulletImpactEffect
        };
    }

    public ProjectileStats GetProjectileStats(string projectileTag)
    {
        if (projectileStats.TryGetValue(projectileTag, out ProjectileStats stats))
        {
            return stats;
        }

        Debug.LogWarning($"Projectile tag '{projectileTag}' not found! Returning default stats.");
        return new ProjectileStats { damage = 5, speed = 10f, lifespan = 1f, impactEffect = null };
    }
}
