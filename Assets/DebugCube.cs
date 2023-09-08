using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCube : MonoBehaviour
{
    private Mesh mesh;
    private Material material;



    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(Color color)
    {
        material.color = color;
    }


}
