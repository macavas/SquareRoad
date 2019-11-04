using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = target.position + new Vector3(0, 0, -50);
        transform.position = newPos;
    }
}
