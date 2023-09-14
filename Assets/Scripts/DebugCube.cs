using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugCube : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro text2;

    

    public void ChangeText(string debug)
    {
        text.text = debug;
        Debug.Log("testing");
    }

    public void ChangeText2(string debug2)
    {
        text2.text = debug2;
    }


}
