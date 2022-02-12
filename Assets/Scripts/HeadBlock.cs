using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadBlock : MonoBehaviour
{
    //private Collider head;
    public GameObject head;


    void Start()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            head.SetActive(true);
            Debug.Log("MyOtherTag");
        }
        else
        {
            head.SetActive(false);
            Debug.Log("neTag");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            head.SetActive(true);
            Debug.Log("MyOtherTag");
        }
 
    }
    private void OnTriggerExit(Collider other)

    {
        if (other.gameObject.tag == "Wall")
        {
            head.SetActive(false);
            Debug.Log("neTag");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
