using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BowDebugger : MonoBehaviour
{
    public bool isDebugMode;

    bool spacebarpressed = false;
    bool bKeyPressed = false;

    public GameObject bow;
    public GameObject bowString;

    private ArrowSpawner arrowSpawner;
    private PullString pullString;
    private XRGrabInteractable bowXR;

    private void Start()
    {
        arrowSpawner = bow.GetComponent<ArrowSpawner>();
        pullString = bowString.GetComponent<PullString>();
        bowXR = bow.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDebugMode == false)
        {
            return;
        }

        if(Keyboard.current.spaceKey.isPressed && spacebarpressed == false)
        {
            spacebarpressed = true;

            pullString.CalculatePull(new Vector3(-10f, 0, -10f));

            pullString.ReleaseString();

            arrowSpawner.debugMode = true;
            StartCoroutine("KeyDelay");
        }


        if(Keyboard.current.bKey.isPressed && bKeyPressed == false)
        {
            bKeyPressed = true;
            pullString.pullDistance = 1;
            pullString.UpdateString();
             
        }

    }


    private IEnumerator KeyDelay()
    {
        yield return new WaitForSeconds(1f);
        spacebarpressed = false;
        bKeyPressed = false;

        Debug.Log("ready to fire");
    }
}
