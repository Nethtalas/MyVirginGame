using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootForward : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public float lifespan;
    public GameObject EnemyBulletExplotion;
    public LayerMask _layermask = 1 << 3;


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

            rb.velocity = rb.transform.forward * Speed;
        }


        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.layer != 7)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            position.y -= 0.5f;
            var explotion = Instantiate(EnemyBulletExplotion, position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explotion, 0.5f);
        }
    }
}
