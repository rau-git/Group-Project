using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Header("Assignables")]
    private Rigidbody _rigidbody;
    private PlayerFunctions _playerFunctions;
    [SerializeField] private EnemyStats _enemyStats;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFunctions>();
    }

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * 200);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("DamageObject")) return;
        
        if (other.gameObject.CompareTag("Player"))
        {
            _playerFunctions.TakeDamage(_enemyStats._enemyBaseDamage);
            Destroy(gameObject);
        }

        if (!other.gameObject.CompareTag("Enemy") || !other.gameObject.CompareTag("DamageObject"))
        {
            Destroy(gameObject);
        }
    }
}
