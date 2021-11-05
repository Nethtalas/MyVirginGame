using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 100f;
    public float lifespan = 5f;
    public GameObject BulletExplotion;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        var currentSpeed = rb.velocity.magnitude;
        if (currentSpeed < Speed)
        {

            rb.velocity = rb.transform.up * Speed;
        }
        

        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {  
            var explotion = Instantiate(BulletExplotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explotion, 0.5f);
        }
    }

}
