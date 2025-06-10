using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShooterTagParent : MonoBehaviour
{
    public string gunName;
    private GunName nameMethod;
  
    void Start()
    {
        nameMethod = GetComponent<GunName>();
        nameMethod.setName(gunName);
    }

}
