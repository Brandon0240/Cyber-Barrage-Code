using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setUltimateCharge(int charges, int maxCharge)
    {
        slider.maxValue = maxCharge;
        slider.value = charges;

        fill.color = gradient.Evaluate(1f);
    }
}
