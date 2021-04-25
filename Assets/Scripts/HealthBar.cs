using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetHealth(float healthIn) {
        healthSlider.value = healthIn;
    }
}
