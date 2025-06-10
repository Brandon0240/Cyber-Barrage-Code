using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTag : MonoBehaviour
{
    private string shooterTag; //  the tag or ID of the shooter
   // private string gunName;
    public void SetShooterTag(string tag)
    {
        shooterTag = tag;
       
    }
    public string getShooterTag()
    {
        return shooterTag;
    }
}
