using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BatteryPercentage : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBattery(float battery)
    {
        slider.maxValue = battery;
        slider.value = battery;
    }

    public void SetBattery(float battery)
    {
        slider.value = battery;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
