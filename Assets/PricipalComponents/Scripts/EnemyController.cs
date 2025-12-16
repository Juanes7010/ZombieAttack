using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    

    AI_Enemy ai_Enemy;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        ai_Enemy = GetComponent<AI_Enemy>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (health.ReturnGameOver())
        {
            ai_Enemy.velocity = 0;
        }
    }

    
}
