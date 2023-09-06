using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{

    public TargetManager targetManager;

    private float startPos;

    private float lowestPoint = 2f;
    private float highestPoint = 9f;

    public float speed = 5.0f;

    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            //this.gameObject.SetActive(false);
            scoreManager.ChangeScore(1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        //if (Random.value%2 == 0)
        //{
        //    startPos = lowestPoint;
        //}
        //else if (Random.value % 2 == 1) 
        //{
        //    startPos = highestPoint;
        //}

        //Vector3 randLocation = new Vector3(this.gameObject.transform.position.x, startPos, this.gameObject.transform.position.z);
        //this.gameObject.transform.position = randLocation;
    }



    private void TravelUp()
    {

    }

    private void TravelDown()
    {

    }

    // Update is called once per frame
    void Update()
    {
    //    if(this.gameObject.transform.position.y > lowestPoint)
    //    {
    //        transform.Translate(Vector3.right * Time.deltaTime);
    //    }
    //    else if(this.gameObject.transform.position.y < highestPoint)
    //    {
    //        transform.Translate(Vector3.left * Time.deltaTime);
    //    }
        
    }
}
