using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{


    public GameObject target;

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

    private void Awake()
    {
        
    }

    private void Start()
    {
        for(int i = 0; i < diamondStartPos.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = new Vector3(0, diamondStartPos[i].y, diamondStartPos[i].z);
            copyTarget.GetComponent<TargetController>().InitiateTarget(diamondStartPos, i);
        }
    }


}
