﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxProgress(float maxProgress)
    {
        slider.maxValue = 10.0f;
    }
    public void SetProgress(float progress)
    {
        slider.value = progress;
    }
}
