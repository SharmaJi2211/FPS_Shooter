using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();    
    }
    void Start()
    {
        target = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
