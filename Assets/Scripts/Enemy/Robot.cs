using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController target;
    NavMeshAgent agent;
    EnemyHealth health;
    const string PLAYER = "Player";
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();    
    }
    void Start()
    {
        target = FindFirstObjectByType<FirstPersonController>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (!target) return;
        agent.SetDestination(target.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER))
        {
            health.selfDestruct();
        }    
    }
}
