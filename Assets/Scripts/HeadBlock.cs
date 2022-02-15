using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadBlock : MonoBehaviour
{
    //private Collider head;
    public GameObject head;
    public GameObject canvas;



    void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            head.SetActive(true);
            canvas.SetActive(true);
        }
 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            head.SetActive(true);
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.gameObject.tag == "Wall")
        {
            head.SetActive(false);
            canvas.SetActive(false);

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
