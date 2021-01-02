using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public int playerMaxValue = 100;

    private void Start()
    {
        HealthSlider.maxValue = playerMaxValue;
    }

    private void Update()
    {
        HealthSlider.value = PlayerControl.instance.currentPlayer.getHealth();
    }

    public void setToMaxHealth()
    {
        HealthSlider.value = playerMaxValue;
    }

    public void setHealth(int health)
    {
        HealthSlider.value = health;
    }
}
