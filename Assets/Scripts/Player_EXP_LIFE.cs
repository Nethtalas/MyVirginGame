using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_EXP_LIFE : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public Slider slider;
    
   

    public float Exp = 0;
    public LayerMask _Layermask;
    public GameObject PlayerDeath;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if (Health < 1)
        {
            GameObject dead = Instantiate(PlayerDeath, transform.position, transform.rotation) as GameObject;
            Destroy(dead, 1);
            Destroy(gameObject);
        }


    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Health--;
        }
        if (other.gameObject.layer == 10)
        {
            Health++;
            //Exp++;
            StartCoroutine(ExperienceAnimation());
        }
    }

    IEnumerator ExperienceAnimation()
    {
        anim.SetBool("PickUpExp", true);
        yield return new WaitForSeconds(.6f);
        anim.SetBool("PickUpExp", false);

    }

}
