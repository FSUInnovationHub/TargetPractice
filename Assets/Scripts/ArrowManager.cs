using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrow;
    public GameObject notch;

    private XRGrabInteractable bow;
    private bool bowLoaded = false;
    private GameObject currentArrow;

    // Start is called before the first frame update
    void Start()
    {
        bow = GetComponentInParent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bow.isSelected && bowLoaded == false)
        {
            bowLoaded = true;
            SpawnArrow();
        }
        if (!bow.isSelected)
        {
            Destroy(currentArrow);
            bowLoaded = false;
        }
    }

    public void EmptyBow()
    {
        bowLoaded = false;
    }

    void SpawnArrow()
    {
        currentArrow = Instantiate(arrow, notch.transform);
    }
}
