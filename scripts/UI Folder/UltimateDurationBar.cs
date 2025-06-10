using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateDurationBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxDuration(float duration)
    {
        slider.maxValue = duration;
        slider.value = duration;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetDuration(float timeLeft)
    {
        slider.value = timeLeft;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
