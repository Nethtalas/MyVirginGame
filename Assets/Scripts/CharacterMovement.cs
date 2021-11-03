using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;

    public float Jumpspeed = 8.0f;
    public float Speed = 10.0f;
    public float GravityValue = -9.81f;
    public Camera Camera;
    public GameObject Head;
    public GameObject Headgun;
    public float DashTime = 2f;
    public float Dashspeed = 5f;
    public float FireRate = 0.5f;
    public float nextFire = 0.5f;
    public float ProjectileSpeed = 25f;
    public GameObject Projectile;
    public Rigidbody rb;
    public LayerMask IgnoreLayer = 1<<6;

    private Vector3 playerVelocity = Vector3.zero;
    private bool groundedPlayer;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * Speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += GravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        HeadRotateTowardsMouse(move);

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Dash());
        }

        FireWeapon();
    }
    private void FixedUpdate()
    {
        
    }

    private void FireWeapon()
    {
       if (Input.GetButton("FireMouse") && Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            GameObject bullet = Instantiate(Projectile, Headgun.transform.position, Headgun.transform.rotation) as GameObject;
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + DashTime)
        {
            controller.Move(transform.forward * Dashspeed * Time.deltaTime);
            yield return null;
        }
    }

    private void HeadRotateTowardsMouse(Vector3 move)
    {

        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 100f, ~IgnoreLayer))
        {
            var target = hitInfo.point;
            Vector3 headPosition = Headgun.transform.position;
            target.y = headPosition.y;
            Head.transform.LookAt(target);
        }

    }
}
