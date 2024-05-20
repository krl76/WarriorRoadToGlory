using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _speed;
    private NavMeshAgent _navmesh;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navmesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _navmesh.speed = _speed;
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _point.position);
        if (distance < _attackRange)
        {
            _animator.SetBool("isAttacking", true);
            _animator.SetBool("isChasing", false);
            _navmesh.SetDestination(gameObject.transform.position);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
            _animator.SetBool("isChasing", true);
            _navmesh.SetDestination(_point.position);
        }
        
    }
}
