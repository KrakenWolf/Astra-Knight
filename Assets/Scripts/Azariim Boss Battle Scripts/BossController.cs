using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{

    private Animator animBoss;
    public Transform playerPos;

    public static bool bossIsDead;

    public GameObject startPortal;
    public GameObject endPortal;
    public GameObject boss;

    //Boss Health
    public float currentHealth;
    public float maxHealth = 100;

    public GameObject azariimHealth;
    public Slider azariimSlider;

    public float speed = 5f;
    public float rotationSpeed = 5f;

    public GameObject player;

    void awake()
    {
        currentHealth = maxHealth;
        maxHealth = currentHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        animBoss = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        ControlHealth();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, player.transform.localPosition, Time.deltaTime * speed);
        transform.LookAt(playerPos);
        BossDead();
    }

    private void OnAnimatorMove()
    {
        if (animBoss.transform)
        {
            animBoss.SetBool("Walking", true);
        }
        else animBoss.SetBool("Walking", false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("level 2"))
        {
            animBoss.SetTrigger("Attacking");
        }
    }

    void BossDead()
    {
        if (bossIsDead == true)
        {
            startPortal.SetActive(false);
            endPortal.SetActive(true);
            boss.SetActive(false);
        }
        if (bossIsDead == false)
        {
            startPortal.SetActive(true);
            endPortal.SetActive(false);
            boss.SetActive(true);
        }
    }

    void ControlHealth()
    {
        azariimSlider.value = CalculateHealth();

        if (currentHealth < maxHealth)
        {
            azariimHealth.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            bossIsDead = true;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        float CalculateHealth()
        {
            return currentHealth / maxHealth;
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            TakeDamage(5);
        }
    }
}
