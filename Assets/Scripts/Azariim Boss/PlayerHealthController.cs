using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject playerHealth;
    public Slider playerSlider;

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
        playerSlider.value = CalculateHealth();

        if (health < maxHealth)
        {
            playerHealth.SetActive(true);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(5);
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