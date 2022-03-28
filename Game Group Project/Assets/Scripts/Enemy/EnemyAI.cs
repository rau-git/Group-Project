using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private AudioSource _audioSource;
    private NavMeshAgent _agent;
    private GameObject _player;
    private EnemyStats _enemyStats;

    private enum States
    {
        IdleState,
        ChaseState,
        AttackState
    }

    [SerializeField] private States _enemyState;

    private void FixedUpdate()
    {
        CheckCurrentState();
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyStats = GetComponent<EnemyStats>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Start() => _enemyState = States.IdleState;

    private void CheckCurrentState()
    {
        switch (_enemyState)
        {
            case States.IdleState:
                IdleToChase();
                break;

            case States.ChaseState:
                ChaseToAttackOrIdle();
                break;
            
            case States.AttackState:
                AttackToChase();
                break;
        }
    }

    private void IdleToChase()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _enemyStats._enemyVisionRange)
        {
            _enemyState = States.ChaseState;
            _audioSource.Play();
        }
    }

    private void ChaseToAttackOrIdle()
    {
        RunToPlayer();

        if (Vector3.Distance(transform.position, _player.transform.position) < _enemyStats._enemyAttackRange)
        {
            _enemyState = States.AttackState;
        }

        if (Vector3.Distance(transform.position, _player.transform.position) > _enemyStats._enemyVisionRange)
        {
            _enemyState = States.IdleState;
        }
    }

    private void AttackToChase()
    {
        _agent.SetDestination(transform.position);
        
        if (Vector3.Distance(transform.position, _player.transform.position) > _enemyStats._enemyAttackRange)
        {
            _enemyState = States.ChaseState;
        }
    }

    private void RunToPlayer() => _agent.SetDestination(_player.transform.position);
}
