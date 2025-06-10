using UnityEngine;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour
{
    public int maxAbilities = 3;
    private List<Ability> abilities = new List<Ability>();

    public GameObject dashAbilityPrefab; 
    public GameObject grenadeAbilityPrefab;

    public GameObject jetPackAbilityPrefab;
    public GameObject rocketBurstAbilityPrefab;
    public void AddAbility(Ability newAbility)
    {
        if (abilities.Count >= maxAbilities)
        {
            Debug.Log("Ability slots full!");
            return;
        }
        abilities.Add(newAbility);

    }

    private void Update()
    {
        foreach (var ability in abilities)
        {
            if (Input.GetKeyDown(ability.activationKey))
            {
                ability.TryActivate();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddDashAbility();
        }
    }

    private void AddDashAbility()
    {
        if (dashAbilityPrefab != null)
        {
            Ability jetPack = Instantiate(jetPackAbilityPrefab, transform).GetComponent<Ability>();
            AddAbility(jetPack);
            Ability grenadeThrow = Instantiate(grenadeAbilityPrefab, transform).GetComponent<Ability>();
            AddAbility(grenadeThrow);
            Ability rocketBurst = Instantiate(rocketBurstAbilityPrefab, transform).GetComponent<Ability>();
            AddAbility(rocketBurst);
        }
        else
        {
            Debug.LogWarning("Dash ability prefab not assigned in AbilityManager!");
        }
    }
}
