using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject elenor1;
    public GameObject astra1;
    public GameObject astra2;
    public GameObject elenor2;
    public GameObject astra3;

    void Start()
    {
        elenor1.SetActive(true);
    }

    void Update()
    {
        if (elenor1 == true)
        {
            StartCoroutine("Text1");
        }
        if(astra1 == true)
        {
            StartCoroutine("Text2");
        }
        if(astra2 == true)
        {
            StartCoroutine("Text3");
        }
        if(elenor2 == true)
        {
            StartCoroutine("Text4");
        }
    }

    IEnumerator Text1()
    {
        yield return new WaitForSeconds(3.28f);
        Destroy(elenor1);
        astra1.SetActive(true);
        StopCoroutine("Text1");
    }
    IEnumerator Text2()
    {
        yield return new WaitForSeconds(6);
        Destroy(astra1);
        astra2.SetActive(true);
        StopCoroutine("Text2");
    }

    IEnumerator Text3()
    {
        yield return new WaitForSeconds(8);
        Destroy(astra2);
        elenor2.SetActive(true);
        StopCoroutine("Text3");
    }

    IEnumerator Text4()
    {
        yield return new WaitForSeconds(12);
        Destroy(elenor2);
        astra3.SetActive(true);
    }
}
