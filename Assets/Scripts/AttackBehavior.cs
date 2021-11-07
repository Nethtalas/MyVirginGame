using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBehavior : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public Slider HealthSlider;
    public GameObject HealthBarUI;

    public GameObject DeathExplotion;
    public GameObject DeathSmoke;
    public GameObject Experience;
    public float ExperienceYeld = 3;

    public GameObject Head;
    public GameObject HeadGun;
    public GameObject EnemyProjectile;
    public GameObject Target;
    public float AttackRange = 8f;
    [SerializeField] private float cooldown = 1;
    private float cooldownTimer;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        HealthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        

        var TargetPosition = Target.transform.position;
        TargetPosition.y = Head.transform.position.y;

        float Range = Vector3.Distance(transform.position, Target.transform.position);
        if (Range < AttackRange)
        {
            Head.transform.LookAt(TargetPosition);
            ShootAtTarget();
        }


        HealthSlider.value = CalculateHealth();

        if (Health < MaxHealth)
        {
            HealthBarUI.SetActive(true);
        }
        if (Health <= 0)
        {
            Vector3 position = new Vector3(transform.position.x, (transform.position.y + 2f), transform.position.z);
            GameObject explode = Instantiate(DeathExplotion, transform.position, transform.rotation) as GameObject;
            GameObject smoke = Instantiate(DeathSmoke, position, transform.rotation) as GameObject;
            Destroy(explode, 3);
            Destroy(smoke, 10);
            Destroy(gameObject);
            for (int i = 0; i < 3; i++)
            {
                GameObject experience = Instantiate(Experience, transform.position, transform.rotation) as GameObject;
            }
        }
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    private void ShootAtTarget()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return;
        cooldownTimer = cooldown;
        GameObject tempBullet = Instantiate(EnemyProjectile, HeadGun.transform.position, Head.transform.rotation) as GameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Health--;
        }
    }
}
