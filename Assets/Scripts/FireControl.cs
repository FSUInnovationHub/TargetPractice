using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireControl : MonoBehaviour
{
    public GameObject projectile;

    float launchSpeed = 1000f;
    

    public void Fire()
    {
        GameObject newObject = Instantiate(projectile, projectile.transform.position, projectile.transform.rotation, null);

        newObject.SetActive(true);

        if (newObject.TryGetComponent(out Rigidbody rb))
        {
            ApplyForce(rb);
        }
    }

    private void ApplyForce(Rigidbody rb)
    {
        Vector3 force = projectile.transform.forward * launchSpeed;
        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
