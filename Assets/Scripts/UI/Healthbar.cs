using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Gradient healthColor;

    void Start()
    {
        GameManager.healthChanged += UpdateHealthbar;
    }

    void OnDestroy()
    {
        GameManager.healthChanged -= UpdateHealthbar;
    }

    /// <summary>
    /// Updates healthbar visuals.
    /// </summary>
    /// <param name="value">health percentage as a float from 0-1.</param>
    public void UpdateHealthbar(float value)
    {
        slider.value = value;
        fillImage.color = healthColor.Evaluate(value);
    }
}
