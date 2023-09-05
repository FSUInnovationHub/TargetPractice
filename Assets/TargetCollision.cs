using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{

    public TargetManager targetManager;

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
        float startPos = Random.value * 10;
        if (startPos < lowestPoint)
        {
            lowestPoint = startPos;
        }
        else if (startPos > highestPoint) 
        { 
            highestPoint = startPos;
        }


        Vector3 randLocation = new Vector3(this.gameObject.transform.position.x, startPos, this.gameObject.transform.position.z);
        this.gameObject.transform.position = randLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y < lowestPoint)
        {
            transform.Translate(speed * Vector3.up * Time.deltaTime);
        }
        else if(this.gameObject.transform.position.y > highestPoint)
        {
            transform.Translate(speed * Vector3.down * Time.deltaTime);
        }
        
    }
}
