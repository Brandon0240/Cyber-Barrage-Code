using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public Sprite abilityIcon;
    public KeyCode activationKey;
    public float cooldownTime = 1f;
    private bool isOnCooldown = false;
    private bool noCooldown = false;


    public abstract void Activate(); 

    public void TryActivate()
    {
        if (!isOnCooldown)
        {
            Activate();
            StartCoroutine(StartCooldown());
        }
        else
        if (noCooldown)
        {
            Activate();
    
        }
        else
        {
            Debug.Log(abilityName + " is on cooldown!");
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
    public void setNoCooldown(bool noCooldown)
    {
        this.noCooldown = noCooldown;
    }
}
