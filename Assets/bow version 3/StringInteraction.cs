using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Assets.Scripts.Events;
using System.Data;
using Unity.VisualScripting;

public class StringInteraction : XRBaseInteractable
{
    public GameEventFloat OnStringReleased;

    public Transform rest;
    public Transform fullTension;

    public GameObject notch;

    public float stringTension;

    private LineRenderer lineRenderer;
    private IXRSelectInteractor interactor;

    protected override void Awake()
    {
        base.Awake();
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetPullInteractor(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject;
    }

    public void Release()
    {
        ArrowManager arrowManager = GetComponent<ArrowManager>();
        arrowManager.EmptyBow();
        OnStringReleased.Raise(stringTension);
        interactor = null;
        stringTension = 0;
        UpdateString();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if ((updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic))
        {
            Vector3 pullPosition = interactor.transform.position;
            stringTension = CalculatePull(pullPosition);

            Haptics();
            UpdateString();
        }
    }

    private void Haptics()
    {
        if (interactor != null)
        {
            ActionBasedController controller = interactor.transform.GetComponent<ActionBasedController>();
            controller.SendHapticImpulse(stringTension, 0.1f);
        }
    }

    private float CalculatePull(Vector3 pullPosition)
    {
        Vector3 pullDirection = pullPosition - rest.position;
        Vector3 targetDirection = fullTension.position = fullTension.position;
        float maxLength = targetDirection.magnitude;

        targetDirection.Normalize();
        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    private void UpdateString()
    {
        Vector3 linePosition = Vector3.forward * Mathf.Lerp(rest.transform.localPosition.z, fullTension.transform.localPosition.z, stringTension);

        lineRenderer.SetPosition(1, linePosition);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
