using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject armaActivar;

    bool gun = false;
    Animator anim;

    private void Start()
    {
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            armaActivar.SetActive(true);
            gameObject.SetActive(false);
            anim.SetBool("Gun", true);
            gun = true;
        }
    }

    public bool ReturnGun()
    {
        return gun;
    }
}
