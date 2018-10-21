using UnityEngine.AI;
using System.Collections;
using UnityEngine;


public class NavTest : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = target.position;
    }
}