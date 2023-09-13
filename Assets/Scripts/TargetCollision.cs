using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    private Vector3 startPos;
    private int arrayPos;

    private void Awake()
    {
        
    }


    public void InitiateTarget(Vector3[] targetPosArray, int stage)
    {
        startPos = this.transform.localPosition;
        arrayPos = stage;

        if(arrayPos == targetPosArray.Length - 1 || arrayPos == targetPosArray.Length)
        {
            arrayPos = -1;
        }

        arrayPos++;
        StartCoroutine(MoveTarget(targetPosArray, 3));
    }

    private IEnumerator MoveTarget(Vector3[] targetPosArray, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(startPos, targetPosArray[arrayPos], time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosArray[arrayPos];
        //arrayPos += 1;
        InitiateTarget(targetPosArray, arrayPos);

    }




}
