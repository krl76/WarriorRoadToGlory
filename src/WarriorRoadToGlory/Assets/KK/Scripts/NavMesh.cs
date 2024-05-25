using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _speed;
    [SerializeField] public Transform pointToSee;

    private PointOfAttack _pointsScript;
    private NavMeshAgent _navmesh;
    private Animator _animator;
    public Transform pointOfAttack;

    private Transform[] _pointsSpawn;
    private Transform[] _pointsAll;
    private int _numberOfPoint;

    private void Awake()
    {
        Random rand = new Random();
        _pointsScript = FindObjectOfType<PointOfAttack>();
        pointToSee = GameObject.FindGameObjectWithTag("PointSee").transform;
        _animator = GetComponent<Animator>();
        _navmesh = GetComponent<NavMeshAgent>();
        _pointsSpawn = _pointsScript._pointsForSpawn;
        _pointsAll = _pointsScript._allPoints;
        _numberOfPoint = rand.Next(0, _pointsSpawn.Length);
        try
        {
            pointOfAttack = _pointsSpawn[_numberOfPoint];
            if (pointOfAttack == null)
                throw new Exception();
            _pointsSpawn[_numberOfPoint] = null;
        }
        catch
        {
            while (pointOfAttack == null)
            {
                _numberOfPoint = rand.Next(0, _pointsSpawn.Length);
                pointOfAttack = _pointsSpawn[_numberOfPoint];
            }
            _pointsSpawn[_numberOfPoint] = null;
        }
    }

    private void Start()
    {
        _navmesh.speed = _speed;
    }

    private void Update()
    {
        Debug.Log($"{_numberOfPoint} - {gameObject.name}");
        Vector3 lookAt = pointToSee.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
        float distance = Vector3.Distance(gameObject.transform.position, pointOfAttack.position);
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
            _navmesh.SetDestination(pointOfAttack.position);
        }
        
    }
}