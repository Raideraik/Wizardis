using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPos;
    private VrRig vrRig;

    public float speedTreshold = 0.1f;
    [Range (0,1)]
    public float smoothing = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VrRig>();
        previousPos = vrRig.head.vrTarget.position;
    }

    void Update()
    {
        //compute the speed
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previousPos) / Time.deltaTime;
        headsetSpeed.y = 0;

        //local Speed
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        //Set Animator Values
        float previousDirectionX = animator.GetFloat("DirectionX");
        float previousDirectionY = animator.GetFloat("DirectionY");



        animator.SetBool("isMoving", headsetSpeed.magnitude > speedTreshold);
        animator.SetFloat("DirectionX", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.x,-1,1) , smoothing));
        animator.SetFloat("DirectionY", Mathf.Lerp(previousDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1) , smoothing));

    }
}
