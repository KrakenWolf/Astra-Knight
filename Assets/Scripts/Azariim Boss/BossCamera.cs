using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You need to create an empty, attach this script to it, then parent your camera to that empty. After that just drag your char object to Public Transform player

public class BossCamera : MonoBehaviour
{

    #region Fields

    private Vector3 targetchords;

    //   | CAMERA WILL MATCH ROTATION OF ANY OBJECT YOUR STICK IN HERE|
    //   v                                                            v
    public Transform player;
    //   ^                                                            ^
    //   |                                                            |

    public float Turnspeed = 2.0f;
    public Quaternion Turnto;

    [Header(header: "Offset")]
    public Vector3 offset;

    #endregion

    private void Start()
    {
        targetchords = player.transform.position;
    }

    void Update()
    {
        Turnto = player.transform.rotation;
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, Turnto, Time.deltaTime * Turnspeed);

    }

}