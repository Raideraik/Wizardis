using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{



    //physics movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    void Start()
    {


        //physics Movement
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;
        body.maxAngularVelocity = 20f;

        //teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;

    }

    void Update()
    {


        PhysicsMove();
    }

    private void PhysicsMove()
    {
        //position
        var positionWithOffset =followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position)/Time.deltaTime ; 
        
        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var quaternion = rotationWithOffset * Quaternion.Inverse(body.rotation);
        quaternion.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = angle * axis * Mathf.Deg2Rad * rotateSpeed ;
    }


}
