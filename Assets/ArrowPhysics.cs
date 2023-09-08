using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowPhysics : MonoBehaviour
{

    public GameObject bow;

    public float speed = 10f;

    private Rigidbody rb;
    private bool inAir = false;
    private PullString pullString;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        bow = this.transform.parent.gameObject;
        pullString = GetComponentInParent<PullString>();

        Stop();
    }

    private void Start()
    {

    }

    private void OnDestroy()
    {

    }

    public void Release(float value)
    {

        if (inAir == false) 
        {
            this.gameObject.transform.parent = null;
            inAir = true;
            SetPhysics(true);

            Vector3 force = transform.forward * speed;
            rb.AddForce(force, ForceMode.Impulse);

            StartCoroutine(RotateWithVelocity());

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Rigidbody body) && collision.transform.TryGetComponent(out ArrowSpawner arrowSpawner) == false)
        {
            rb.interpolation = RigidbodyInterpolation.None;
            transform.parent = collision.transform;
            //body.addforce
            Stop();
        }
        
    }

    private void Stop()
    {
        //inAir = false;
        SetPhysics(false);
    }

    private void SetPhysics(bool usePhysics)
    {
        rb.useGravity = usePhysics;
        rb.isKinematic = !usePhysics;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
