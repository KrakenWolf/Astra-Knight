using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPortal : MonoBehaviour
{
    public GameObject startPortal;
    public GameObject endPortal;
    public GameObject boss;

    public bool bossIsDead;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
