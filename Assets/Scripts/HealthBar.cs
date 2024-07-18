using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider sliderBar;

    [SerializeField] private Vector3 offset;

    public void SetHealth(float health, float maxHealth)
    {
        sliderBar.gameObject.SetActive(health < maxHealth);

        sliderBar.value = health;

        sliderBar.maxValue = maxHealth;
    }

    private void Update()
    {
        sliderBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
}