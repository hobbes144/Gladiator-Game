using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    // private Player_Equiped player;

    private void Start()
    {
        // player = GameObject.FindWithTag("player").GetComponent<Player_Equiped>();
    }

    public void setMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setHealth(float currHealth)
    {
        slider.value = currHealth;
    }
}
