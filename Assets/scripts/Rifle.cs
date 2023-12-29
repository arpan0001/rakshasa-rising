using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rif1e Things")]
    public Camera cam;
    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public Transform hand;
    public Animator animator;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject ConcreteEffect;
    public GameObject goreEffect;

    private void Awake()
    {
        transform.SetParent(hand);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
          
           Shoot();
        }
        else if(Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FireWalk", true);

        }
        else if(Input.GetButton("Fire2") && Input.GetButton("Fire1"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("idleAim", true);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloading", false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
        }
  
    }

    private void Shoot()
    {
        muzzleSpark.Play();
        RaycastHit hitInfo;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            ObjectToHit objectToHit = hitInfo.transform.GetComponent<ObjectToHit>();
            zombie1 zombie1 = hitInfo.transform.GetComponent<zombie1>();

            if(objectToHit != null)
            {
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject ConcreteGo = Instantiate(ConcreteEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(ConcreteGo, 1f);
            }
            else if(zombie1 != null)
            {
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1f);
            }

        }
        
    }

    private void Reload()
    {
        animator.SetBool("Reloading", true);
        animator.SetBool("Reloading", false); 
    }
}
