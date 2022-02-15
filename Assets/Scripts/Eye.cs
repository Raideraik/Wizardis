using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform eye; // Camera (eye)
    public Transform collisionVolume; // Your Collider


    void FixedUpdate()
    {
        Vector3 eyePos = eye.transform.position;
        eyePos.y = collisionVolume.transform.position.y;
        collisionVolume.transform.position = eyePos;
    }
}
