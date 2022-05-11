using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamage<float>, IKill
{
    [Header("Assignables")]
    private EnemyStats _enemyStats;

    [SerializeField] private GameObject _deathVFX;

    private PlayerFunctions _playerFunctions;
    private GameManagement _gameManagement;

    private bool _canTakeDamage = true;

    private void Awake()
    {
        _enemyStats = GetComponent<EnemyStats>();
        _gameManagement = GameObject.FindWithTag("GameManager").GetComponent<GameManagement>();
        _playerFunctions = GameObject.FindWithTag("Player").GetComponent<PlayerFunctions>();

        _enemyStats._enemyCurrentHealth = _enemyStats._enemyMaxHealth;
    }

    private void Start()
    {
        _enemyStats._enemyMaxHealth *= _gameManagement._currentDifficulty;
        _enemyStats._enemyBaseDamage *= _gameManagement._currentDifficulty;
        _enemyStats._enemyCurrentHealth = _enemyStats._enemyMaxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        if (!_canTakeDamage) return;

        if (_enemyStats._enemyCurrentHealth - damageTaken <= 0)
        {
            damageTaken = _enemyStats._enemyCurrentHealth;
            _playerFunctions.LifestealFunction(damageTaken);
            KillCharacter();
        }
        else
        {
            _enemyStats._enemyCurrentHealth -= damageTaken;
        }

        _playerFunctions.LifestealFunction(damageTaken);

        StartCoroutine(DamageCooldown());
    }

    public void KillCharacter()
    {
        if (_deathVFX)
        {
            Instantiate(_deathVFX, transform.position - new Vector3(0, 1, 0), transform.rotation);
        }

        _gameManagement._enemiesKilled += 1;
        _gameManagement._currencyCurrent += Mathf.RoundToInt(Random.Range(15, 50) * _gameManagement._currentDifficulty);
        Destroy(gameObject);
    }

    private IEnumerator DamageCooldown()
    {
        _canTakeDamage = false;
        yield return new WaitForSeconds(0.05f);
        _canTakeDamage = true;
    }
}
