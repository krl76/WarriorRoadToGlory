using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _speed;
    [SerializeField] public Transform pointToSee;
    [SerializeField] private EnemyHp _hpFrom;

    private Animator _animator;
    private PointOfAttack _pointsScript;
    private NavMeshAgent _navmesh;
    public Transform pointOfAttack;
    private EnemyHp _enemyHpScript;

    private Transform[] _pointsSpawn;
    private Transform[] _pointsAll;
    private int _numberOfPoint;

    private void Awake()
    {
        Random rand = new Random();
        pointToSee = GameObject.FindGameObjectWithTag("PointSee").transform;
        _pointsScript = FindObjectOfType<PointOfAttack>();
        _animator = GetComponent<Animator>();
        _navmesh = GetComponent<NavMeshAgent>();
        _hpFrom = GetComponentInChildren<EnemyHp>();
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
            int k = 0;
            while (pointOfAttack == null || k < 10)
            {
                _numberOfPoint = rand.Next(0, _pointsSpawn.Length);
                pointOfAttack = _pointsSpawn[_numberOfPoint];
                k++;
                Debug.Log($"k: {k}");
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
        if (_hpFrom._enemyHp <= 0)
        {
            Debug.Log(_hpFrom._enemyHp);
            _animator.enabled = false;
            this.GetComponent<NavMesh>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
        }
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
