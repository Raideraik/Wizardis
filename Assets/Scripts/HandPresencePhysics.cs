using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;
    private Rigidbody rb;
    private Collider[] handColliders;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider() 
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void EnableHandColliderDelay(float delay) 
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider() 
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance>showNonPhysicalHandDistance)
            nonPhysicalHand.enabled = true;
        else
            nonPhysicalHand.enabled = false;

    }

   private void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.deltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
