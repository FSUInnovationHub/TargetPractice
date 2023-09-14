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

    public GameObject currentArrow;
    private GameObject nextArrow;

    public DebugCube debug;

    public bool debugMode = false;

    private float stringDistance;

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
        if((isArrowReady == false && bow.isSelected) || debugMode == true)
        {
            debugMode = false;
            isArrowReady = true;
            //currentArrow = Instantiate(arrow, this.transform);

            StartCoroutine("DelayedSpawn");
        }
        if(!bow.isSelected)
        {
            //Destroy(currentArrow);
            //NotchEmpty();
            
        }
    }

    public void UpdateArrow(float pullDistance)
    {
        if(isArrowReady== true)
        {
            currentArrow.transform.localPosition = new Vector3(0 + (pullDistance/3), 0, 0); //TODO Adjust this for arrow alignment to string

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
        currentArrow = Instantiate(arrow, this.gameObject.transform);
        currentArrow.transform.position = new Vector3(arrowNotch.transform.position.x, arrowNotch.transform.position.y, arrowNotch.transform.position.z - 0.22f);
        currentArrow.transform.rotation = arrowNotch.transform.rotation;

        currentArrow.transform.SetParent(arrowNotch.transform, true);
        Debug.Log("Arrow is ready");
        currentArrow.transform.position = arrowNotch.transform.position;
    }




}
