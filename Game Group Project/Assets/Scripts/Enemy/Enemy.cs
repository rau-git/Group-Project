using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamage<float>, IKill
{
    [Header("Assignables")]
    private EnemyStats _enemyStats;

    private GameObject _camera;

    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _canvas;

    private void Awake()
    {
        _enemyStats = GetComponent<EnemyStats>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");

        _enemyStats._enemyCurrentHealth = _enemyStats._enemyMaxHealth;

        _canvas.SetActive(false);
    }

    private void Update()
    {
        _canvas.transform.LookAt(_camera.transform.position);
    }

    public void TakeDamage(float damageTaken)
    {
        _canvas.SetActive(true);

        if (_enemyStats._enemyCurrentHealth - damageTaken <= 0)
        {
            KillCharacter();
        }
        else _enemyStats._enemyCurrentHealth -= damageTaken;

        UpdateHealthBar();
    }

    public void KillCharacter()
    {
        Destroy(this.gameObject);
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _enemyStats._enemyCurrentHealth / _enemyStats._enemyMaxHealth;
    }

}
