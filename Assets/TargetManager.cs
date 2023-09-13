using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public GameEvent OnTargetsCleared;

    public GameObject target;

    private Vector3[] singleTarget =
    {
        new Vector3 (0,3,0),
    };

    //written as y,z
    private Vector3[] diamondStartPos =
    {
        new Vector3 (0,2,0),
        new Vector3 (0,3.5f,-1.5f),
        new Vector3 (0, 5,-3),
        new Vector3 (0, 6.5f,-1.5f),
        new Vector3 (0,8,0),
        new Vector3 (0, 6.5f, 1.5f),
        new Vector3 (0, 5, 3),
        new Vector3 (0,3.5f,1.5f),
    };
    private Vector3[] fourCorners =
    {
        new Vector3 (0, 6.5f, 0),
        new Vector3 (0, 1.5f, 3),
        new Vector3 (0, 6.5f, -3),
        new Vector3 (0, 1.5f, -3)
    };
    private Vector3[] smallDiamond =
    {
        new Vector3 (0, 5.5f, 0),
        new Vector3 (0, 4f, 1.5f),
        new Vector3 (0, 2.5f, -3),
        new Vector3 (0, 5f, -1.5f)
    };

    private int targetsRemaining;


    private int stage = 0;

    private void Awake()
    {
        targetsRemaining = diamondStartPos.Length + fourCorners.Length + smallDiamond.Length + 3;
    }


    private void Start()
    {
        GameObject  copyTarget = Instantiate(target, this.transform);
        copyTarget.transform.localPosition = new Vector3(0, 3, 0);
        copyTarget.GetComponent<TargetController>().InitiateTarget(singleTarget, 0);
    }

    private void DiamondSetUp()
    {
        for (int i = 0; i < diamondStartPos.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = new Vector3(0, diamondStartPos[i].y, diamondStartPos[i].z);
            copyTarget.GetComponent<TargetController>().InitiateTarget(diamondStartPos, i);
        }
    }

    //TODO because they're in different arrays we need to make sure the targets know the total number
    private void EightCornersSetUp()
    {
        for (int i = 0; i < fourCorners.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = new Vector3(0, fourCorners[i].y, fourCorners[i].z);
            copyTarget.GetComponent<TargetController>().InitiateTarget(fourCorners, i);
        }
        for (int i = 0; i < smallDiamond.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = new Vector3(0, smallDiamond[i].y, smallDiamond[i].z);
            copyTarget.GetComponent<TargetController>().InitiateTarget(smallDiamond, i);
        }

        targetsRemaining = fourCorners.Length + 1;
        targetsRemaining = targetsRemaining + smallDiamond.Length + 1;
    }

    public void ShutDownTargets() //When timer runs out shut down all targets.
    {
        foreach(TargetController target in this.gameObject.GetComponentsInChildren<TargetController>())
        {
            target.TargetHit();
        }
    }

    public void TargetHit()
    {
        targetsRemaining--;

        if(targetsRemaining == 0 )
        {
            OnTargetsCleared.Raise();
        }
    }

    public void NextStage()
    {
        stage++;
        if(stage == 1 )
        {
            DiamondSetUp();
        }
        if(stage == 2 )
        {
            EightCornersSetUp();
        }
        else if(stage == 3 )
        {
            OnTargetsCleared.Raise();
        }
    }


}
