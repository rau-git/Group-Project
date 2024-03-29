using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBotDamage : MonoBehaviour
{
    [Header("Assignables")]
    private PlayerFunctions _playerFunctions;
    [SerializeField] private EnemyStats _enemyStats;

    private void Awake()
    {
        _playerFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFunctions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerFunctions.TakeDamage(_enemyStats._enemyBaseDamage);
        }
    }
}
