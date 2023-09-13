using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowManager : MonoBehaviour
{

    public GameObject topString;
    public GameObject botList;
    public GameObject connectString;

    public LineRenderer topBowString;
    public LineRenderer botBowString;

    public GameObject arrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        topBowString.SetPosition(1, connectString.transform.position);

        botBowString.SetPosition(1, connectString.transform.position);
    }







}
