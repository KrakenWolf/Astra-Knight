using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private Animator animBoss;
    public Transform playerPos;

    public static bool bossIsDead;

    public GameObject startPortal;
    public GameObject endPortal;
    public GameObject boss;

    public float speed = 2f;
    public float rotationSpeed = 5f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        animBoss = GetComponent<Animator>();
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
    private void OnCollisionEnter(Collision collision)
    {
        animBoss.SetTrigger("Attacking");
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
}
