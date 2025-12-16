using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    public float velocity;
    [SerializeField] NavMeshAgent IA;

    Health health;
    Transform startPosition;

    private void Start()
    {
        startPosition = GetComponent<Transform>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        IA.speed = velocity;
        if (!health.ReturnGameOver())
        {
            IA.SetDestination(target.position);
        } else
        {
            IA.SetDestination(startPosition.position);
        }
        
    }
}
