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

<<<<<<< Updated upstream
    private void Awake()
    {
        
    }
=======
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
>>>>>>> Stashed changes

    private void Start()
    {
        for(int i = 0; i < diamondStartPos.Length; i++)
        {
            GameObject copyTarget = Instantiate(target, this.transform);
            copyTarget.transform.localPosition = new Vector3(0, diamondStartPos[i].y, diamondStartPos[i].z);
            copyTarget.GetComponent<TargetController>().InitiateTarget(diamondStartPos, i);
        }
    }

    public void ShutDownTargets() //When timer runs out shut down all targets.
    {
        foreach(TargetController target in this.gameObject.GetComponentsInChildren<TargetController>())
        {
            target.TargetHit();
        }
    }


}
