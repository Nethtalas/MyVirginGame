using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public GameObject Head;
    public GameObject HeadGun;
    public GameObject EnemyProjectile;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var TargetPosition = Target.transform.position;
        //TargetPosition.y = 1.443f;
        TargetPosition.y = Head.transform.position.y;
        Head.transform.LookAt(TargetPosition);
    }
}
