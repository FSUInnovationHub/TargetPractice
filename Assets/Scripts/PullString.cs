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
    public ArrowSpawner arrowSpawner;

    public float pullDistance;

    private LineRenderer lineRenderer;

    private IXRSelectInteractor pullingInteractor = null;

    public Vector3 pullPosition;

    public DebugCube debugCube;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        arrowSpawner = this.GetComponentInParent<ArrowSpawner>();
    }

    public void SetPullInteractorObject(SelectEnterEventArgs args)
    {
        pullingInteractor = args.interactorObject;
    }

    public void ReleaseString()
    {
        onStringReleased.Raise(pullDistance);
        pullingInteractor = null;

        pullDistance = 0f;

        UpdateString();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {

            if(pullingInteractor != null)
            {
                pullPosition = pullingInteractor.transform.position;
                

                pullDistance = CalculatePull(pullPosition);
                debugCube.ChangeText(pullDistance.ToString());
                //Haptics();
                UpdateString();
            }
                
        }
    }

    private void Haptics() // TODO: I believe this is throwing errors during playmode. Not sure why.
    {
        if (pullingInteractor != null)
        {
            ActionBasedController controller = pullingInteractor.transform.GetComponent<ActionBasedController>();
            controller.SendHapticImpulse(pullDistance, 0.1f);
        }
    }

    public float CalculatePull(Vector3 pullPosition)
    {
        Vector3 pullDirection = pullPosition - startPoint.position;
        Vector3 targetDirection = endPoint.position - startPoint.position;
        float maxLength = targetDirection.magnitude;

        targetDirection.Normalize();
        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    public void UpdateString()
    {
        Vector3 linePosition = Vector3.right * Mathf.Lerp(startPoint.transform.localPosition.x, endPoint.transform.localPosition.x, pullDistance) + new Vector3(0,0,-0.1f);
        debugCube.ChangeText2(pullDistance.ToString());
        lineRenderer.SetPosition(1, linePosition);


        //arrowSpawner.UpdateArrow(pullDistance);

    }

}
