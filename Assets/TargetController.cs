using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private Vector3 startPos;
    private int arrayPos;

    private bool isInitialTarget;

    public GameEvent OnGameStart;

    public void InitiateTarget(Vector3[] targetPosArray, int stage)
    {
        startPos = this.transform.localPosition;
        arrayPos = stage;

        if (arrayPos == targetPosArray.Length - 1 || arrayPos == targetPosArray.Length)
        {
            arrayPos = -1;
        }

        arrayPos++;
        StartCoroutine(MoveTarget(targetPosArray, 3));

        if(targetPosArray.Length == 1)
        {
            isInitialTarget = true;
        }
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
        InitiateTarget(targetPosArray, arrayPos);

    }

    public void TargetHit()
    {
<<<<<<< Updated upstream
        StopAllCoroutines();
=======
        if (isInitialTarget)
        {
            OnGameStart.Raise();
        }

        StopAllCoroutines();
        Destroy(this.gameObject, 3f);
>>>>>>> Stashed changes
    }
}
