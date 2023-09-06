using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using Assets.Scripts.Events;

public class PullString : XRBaseInteractable
{

    public GameEventFloat onStringReleased;

    public Transform startPoint;
    public Transform endPoint;

    public GameObject arrowNotch;
    public GameObject arrow;

    public float pullDistance;

    private LineRenderer lineRenderer;

    private IXRSelectInteractor pullingInteractor = null;

    public Vector3 pullPosition;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetPullInteractorObject(SelectEnterEventArgs args)
    {
        pullingInteractor = args.interactorObject;
    }

    public void ReleaseString()
    {
        onStringReleased.Raise(pullDistance);
        pullingInteractor = null;

        pullDistance = -0.05f;
        arrowNotch.transform.localPosition = new Vector3(arrowNotch.transform.localPosition.x, arrowNotch.transform.localPosition.y, 0f);

        UpdateString();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if(isSelected)
            {
                pullPosition = pullingInteractor.transform.position;
                //arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y, pullPosition.z + 0.25f);

                pullDistance = CalculatePull(pullPosition);

                UpdateString();
            }
        }
    }

    private float CalculatePull(Vector3 pullPosition)
    {
        Vector3 pullDirection = pullPosition - startPoint.position;
        Vector3 targetDirection = endPoint.position - startPoint.position;
        float maxLength = targetDirection.magnitude;

        targetDirection.Normalize();
        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    private void UpdateString()
    {
        Vector3 linePosition = Vector3.forward * Mathf.Lerp(startPoint.transform.localPosition.z, endPoint.transform.localPosition.z, pullDistance);
        lineRenderer.SetPosition(1, linePosition);

    }

}
