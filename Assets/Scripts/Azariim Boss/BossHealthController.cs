using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : BossController
{
    public float health;
    public float maxHealth;

    public GameObject azariimHealth;
    public Slider azariimSlider;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControlHealth();
    }

    void ControlHealth()
    {
        azariimSlider.value = CalculateHealth();

        if (health < maxHealth)
        {
            azariimHealth.SetActive(true);
        }

        if (health <= 0)
        {
            bossIsDead = true;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        float CalculateHealth()
        {
            return health / maxHealth;
        }
    }
}
