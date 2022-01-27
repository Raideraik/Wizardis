using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffSetInteractible : XRGrabInteractable
{
    private Vector3 initialAttachLocalPos;
    private Quaternion initailAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initailAttachLocalRot = attachTransform.localRotation;

    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initailAttachLocalRot;
        }

        base.OnSelectEntered(interactor);
    }
}
