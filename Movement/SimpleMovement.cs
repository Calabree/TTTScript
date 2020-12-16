using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent agent;
    private Touch touch;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Follow").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}