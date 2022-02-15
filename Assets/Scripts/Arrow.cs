using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform Point;
    public float speed;

    private void Update()
    {
        transform.LookAt(Point);
    }


}

