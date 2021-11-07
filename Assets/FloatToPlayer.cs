using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToPlayer : MonoBehaviour
{
    public GameObject Player;
    public float speed = 2;
    private Rigidbody rb;
    private Vector3 TargetVector;
    public float PickupRange = 5;
    private float range;
   


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        Vector3 randomOffset = transform.position + randomPosition;
        transform.position = Vector3.MoveTowards(transform.position, randomOffset, Random.Range(1, 3));
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(transform.position, Player.transform.position);

        if (range < PickupRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }
   
 
}
