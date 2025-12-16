using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Animator anim;
    Health health;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        health = collision.gameObject.GetComponent<Health>();
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            if (health != null)
            {
                health.SubtractLife(10);
            }
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Bullet")
        {
            health = GetComponent<Health>();
            health.SubtractLife(30);
            
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }

    void RemoveLife()
    {
        
    }
}
