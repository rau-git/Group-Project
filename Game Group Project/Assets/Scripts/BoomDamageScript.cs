using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDamageScript : MonoBehaviour
{
    [Header("Assignables")]
    private PlayerFunctions _playerFunctions;
    [SerializeField] private EnemyStats _enemyStats;

    private void Awake()
    {
        _playerFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFunctions>();
    }

    private void Start()
    {
        Destroy(gameObject, 1f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayExplosion());
        }
    }

    private IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(0.25f);
        _playerFunctions.TakeDamage(_enemyStats._enemyBaseDamage);
    }
}
