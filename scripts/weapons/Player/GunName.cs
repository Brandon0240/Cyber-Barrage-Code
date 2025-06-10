using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[DefaultExecutionOrder(-100)]
public class GunName : MonoBehaviour
{
    private string name; 

   
    public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }
}
