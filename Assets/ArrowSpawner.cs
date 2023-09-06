using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;
    public GameObject arrowNotch;

    private XRGrabInteractable bow;
    private bool isArrowReady = false;

    private GameObject currentArrow;
    private GameObject nextArrow;

    private void Start()
    {
        bow = GetComponent<XRGrabInteractable>();
        //PullString.stringReleased += NotchEmpty;
    }

    private void OnDestroy()
    {
        //PullString.stringReleased -= NotchEmpty;
    }

    private void Update()
    {
        if(isArrowReady == false)
        {
            isArrowReady = true;
            currentArrow = Instantiate(arrow, arrowNotch.transform);


            //StartCoroutine("DelayedSpawn");
        }
        if(!bow.isSelected)
        {
            Destroy(currentArrow);
            NotchEmpty();
        }
    }

    public void NotchEmpty()
    {
        isArrowReady = false;
    }

    private IEnumerator DelayedSpawn()
    {
        isArrowReady = true;
        yield return new WaitForSeconds(1f);
        currentArrow = Instantiate(arrow, arrowNotch.transform);
    }




}
