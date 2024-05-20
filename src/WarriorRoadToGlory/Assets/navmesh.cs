using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesh : MonoBehaviour
{
    [SerializeField] private Transform point;
    private NavMeshAgent _navmesh;

    private void Awake()
    {
        _navmesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navmesh.SetDestination(point.position);
    }
}
