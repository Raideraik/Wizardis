using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    private ContinousMovement continousMovement;

    public static XRController climbingHand;

    void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (climbingHand)
        {
            continousMovement.enabled = false;
            Climb();
        }
        else
        {
            continousMovement.enabled = true;
        }
    }

    private void Climb() 
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation *-velocity * Time.fixedDeltaTime);
    }
}
