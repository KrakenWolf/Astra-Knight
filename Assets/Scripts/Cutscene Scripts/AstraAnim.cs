using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstraAnim : MonoBehaviour
{
    private Animator animCutscene;

    private float speed = 3f;
    private float speed2 = 0.5f;
    private float speed3 = 2f;

    public GameObject sensor1;

    public GameObject act1Player;
    public GameObject act2Player;
    public GameObject act3Player;

    // Start is called before the first frame update
    void Start()
    {
        animCutscene = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CutSceneAnim();
        act1Player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        act2Player.transform.Translate(Vector3.forward * speed2 * Time.deltaTime);
        act3Player.transform.Translate(Vector3.forward * speed3 * Time.deltaTime);
    }

    void CutSceneAnim()
    {
        if (act1Player.transform)
        {
            animCutscene.SetBool("Running", true);
        }

        if (act2Player)
        {
            animCutscene.SetBool("Idle", true);
        }
        if (act3Player)
        {
            animCutscene.SetBool("Idle", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            act1Player.SetActive(false);
            act2Player.SetActive(true);
        }
        if (other.gameObject.CompareTag("sensor 2"))
        {
            act1Player.SetActive(false);
            act2Player.SetActive(false);
            act3Player.SetActive(true);
        }
    }
}