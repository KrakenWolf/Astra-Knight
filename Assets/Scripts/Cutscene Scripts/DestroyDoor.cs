using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public GameObject doorEffect;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            door.SetActive(false);
        }
    }

    IEnumerator DoorEffect()
    {
        yield return new WaitForSeconds(0.5f);
        doorEffect.SetActive(false);
    }
}
