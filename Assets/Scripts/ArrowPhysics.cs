using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowPhysics : MonoBehaviour
{

    public GameObject bow;

    public float speed = 10f;

    private Rigidbody rb;
    private bool inAir = false;
    private TrailRenderer trailRenderer;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();  
        audioSource = GetComponent<AudioSource>();

        bow = this.transform.parent.gameObject;
    }

    private void Start()
    {
        Stop();
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
            audioSource.Play();

            Vector3 force = transform.forward * speed;
            rb.AddForce(force, ForceMode.Impulse);

            StartCoroutine(RotateWithVelocity());

            bow.GetComponent<ArrowSpawner>().NotchEmpty();

            trailRenderer.emitting = true;

            Destroy(this.gameObject, 5f);
            
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
        Debug.Log("fjdasdf");
        if (collision.transform.TryGetComponent(out Rigidbody body) && collision.transform.TryGetComponent(out TargetController targetController))
        {
            Debug.Log("hazaaah");
            rb.interpolation = RigidbodyInterpolation.None;
            transform.parent = collision.transform;

            body.isKinematic = false;
            body.AddForce(rb.velocity, ForceMode.Impulse);
            targetController.TargetHit();

            Stop();
        }
        
    }

    private void Stop()
    {
        inAir = false;
        SetPhysics(false);
        trailRenderer.emitting = false;
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
