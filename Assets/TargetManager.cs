using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private int targetSet = 0;

    public GameObject target;
    private int targetsSpawned;
    private int targetsLeft;

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

    private void Awake()
    {
        
    }

    private void Start()
    {
        GameObject startTarget = Instantiate(target, this.transform);
        startTarget.transform.localPosition = new Vector3(0, 4, 0);
        targetsSpawned = 1;
        targetsLeft = targetsSpawned;
    }

    public void TargetHit()
    {
        targetsLeft--;
        if(targetsLeft == -1)
        {
            targetSet++;
            NextTargetSet();
        }

    }

    private void NextTargetSet()
    {
        if(targetSet == 1)
        {
            InitializeDiamond();
        }
        if(targetSet == 2)
        {
            InitializeBox();
        }
    }

    private void InitializeDiamond()
    {
        for(int i = 0; i < diamondStartPos.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = diamondStartPos[i];
            copyTarget.GetComponent<TargetController>().InitiateTarget(diamondStartPos, i);
        }
        targetsSpawned = diamondStartPos.Length;
        targetsLeft = targetsSpawned;
    }

    private void InitializeBox()
    {
        for(int i = 0; i < smallDiamond.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = smallDiamond[i];
            copyTarget.GetComponent<TargetController>().InitiateTarget(smallDiamond, i);
        }

        for (int i = 0; i < fourCorners.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = fourCorners[i];
            copyTarget.GetComponent<TargetController>().InitiateTarget(fourCorners, i);
        }

        targetsSpawned = smallDiamond.Length + fourCorners.Length;
        targetsLeft = targetsSpawned;
    }


}
