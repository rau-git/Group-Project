using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Assignables")]
    private EnemyAttack _enemyAttack;
    private NavMeshAgent _agent;
    private GameObject _player;
    private EnemyStats _enemyStats;
    private Animator _animator;

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
        _enemyAttack = GetComponent<EnemyAttack>();
        _player = GameObject.FindGameObjectWithTag("Player");
        
        if (GetComponent<Animator>() != null)
        {
            _animator = GetComponent<Animator>();
        }
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
        if (_animator)
        {
            DisableAllAnimations();
            _animator.SetBool("idleAnimBool",true);
        }

        if (Vector3.Distance(transform.position, _player.transform.position) < _enemyStats._enemyVisionRange)
        {
            _enemyState = States.ChaseState;
        }
    }

    private void ChaseToAttackOrIdle()
    {
        RunToPlayer();
        if (_animator)
        {
            DisableAllAnimations();
            _animator.SetBool("moveAnimBool", true);
        }

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
        var lookPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);

        _agent.SetDestination(transform.position);
        transform.LookAt(lookPosition);
        _enemyAttack._attackBool = true;
        
        if (_animator)
        {
            DisableAllAnimations();
            _animator.SetBool("attackAnimBool", true);
        }
        
        if (Vector3.Distance(transform.position, _player.transform.position) > _enemyStats._enemyAttackRange)
        {
            _enemyState = States.ChaseState;
            _enemyAttack._attackBool = false;
        }
    }

    private void DisableAllAnimations()
    {
        _animator.SetBool("idleAnimBool", false);
        _animator.SetBool("moveAnimBool", false);
        _animator.SetBool("attackAnimBool", false);
    }

    private void RunToPlayer() => _agent.SetDestination(_player.transform.position);
}
