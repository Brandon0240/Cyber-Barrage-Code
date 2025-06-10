using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletStatSheet : MonoBehaviour
{
    private Dictionary<string, int> projectileValues = new Dictionary<string, int>
    {
        { "ShotgunShell", 5 },
        { "AssaultRifle", 1 },
        { "Elite", 250 }
    };

    public int GetBulletDamage(string bulletTag)
    {
        if (projectileValues.TryGetValue(bulletTag, out int damage))
        {
            return damage;
        }

        Debug.LogWarning($"Tag '{bulletTag}' not found in projectileValues! Defaulting to 1 Dps");
        return 1; 
    }
}
