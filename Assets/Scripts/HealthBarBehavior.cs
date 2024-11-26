using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{

    public Slider slider;
    public Color Low;
    public Color High;
    public Vector2 Offset;
    public GameObject sliderPoint;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }


    // Update is called once per frame
    void Update()
    {
        slider.transform.position = sliderPoint.transform.position;
    }
}