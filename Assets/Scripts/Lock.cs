using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject door;
    public GameObject locked;

    public void Unlock() 
    {
        Destroy(door);
        Destroy(locked);
    }
}
