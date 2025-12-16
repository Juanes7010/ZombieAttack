using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;

    Animator anim;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            health = 0;
        }
        if(health == 0 && gameOver == false)
        {
            anim.SetBool("Dead", true);
            gameOver = true;
            if (LayerMask.LayerToName(gameObject.layer) == "Enemy")
            {
                Invoke("Vanish", 5f);
            }
        }
    }

    public bool ReturnGameOver()
    {
        return gameOver;
    }

    public void SubtractLife(float lifeRemove)
    {
        health -= lifeRemove;
    }

    void Vanish()
    {
        Destroy(gameObject);
    }
}
