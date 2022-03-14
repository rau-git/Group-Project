using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Assignables")]
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;

    [Header("Attributes")]
    [Range(0, 20)]
    [SerializeField] private float _viewDistance;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _viewDistance)
        {
            RunToPlayer();
        }
    }

    private void RunToPlayer()
    { 
        _agent.SetDestination(_player.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);
    }
}
