using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPhysics : MonoBehaviour
{

    public GameObject bow;

    public float speed = 20f;
    public Transform head;

    private Rigidbody rb;
    private bool inAir = false;
    private Vector3 lastPosition = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        bow = this.transform.parent.gameObject;
        //PullString.PullActionReleased += Release;

        Stop();
    }

    private void OnDestroy()
    {
        //PullString.PullActionReleased -= Release;
    }

    public void Release(float value)
    {

        if(this.transform.parent.gameObject == bow)
        {
            gameObject.transform.parent = null;
            inAir = true;
            SetPhysics(true);

            Vector3 force = transform.forward * value * speed;
            rb.AddForce(force, ForceMode.Impulse);

            StartCoroutine(RotateWithVelocity());

            lastPosition = this.gameObject.transform.position;

            bow.GetComponent<ArrowSpawner>().NotchEmpty();
        }
        
    }

    

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while(inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(rb.velocity, transform.up);
            transform.rotation = newRotation;
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if(inAir)
        {
            CheckCollision();
            lastPosition = this.transform.position;
        }
    }

    private void CheckCollision()
    { 
        if(Physics.Linecast(lastPosition, this.transform.position, out RaycastHit hitInfo))
        {
            if(hitInfo.transform.gameObject)
            {
                rb.interpolation = RigidbodyInterpolation.None;
                transform.parent = hitInfo.transform;
            }
            //Stop();
        }
    
    }

    private void Stop()
    {
        inAir = false;
        SetPhysics(false);
    }

    private void SetPhysics(bool usePhysics)
    {
        rb.useGravity = usePhysics;
        rb.isKinematic = !usePhysics;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
