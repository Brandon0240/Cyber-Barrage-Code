using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetAmmo(int ammo)
    {
        slider.value = ammo;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
