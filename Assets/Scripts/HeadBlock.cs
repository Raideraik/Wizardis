using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadBlock : MonoBehaviour
{
    //private Collider head;
    public FadeScreen head;
    public Color fadeColor;
    private Renderer rend;

    void Start()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        Color newColor = fadeColor;
        rend.material.SetColor("_Color", newColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
