using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTest : MonoBehaviour
{

    bool turnOn = true;
    

    public void test()
    {
        turnOn = !turnOn;
        this.gameObject.SetActive(turnOn);
    }






}
