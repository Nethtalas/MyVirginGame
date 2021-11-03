using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 30f;
    public float lifespan = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var currentSpeed = rb.velocity.magnitude;
        if (currentSpeed < Speed)
        {
            
            rb.velocity += rb.transform.up * Speed;
        }

        Destroy(gameObject, lifespan);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    
    
}
