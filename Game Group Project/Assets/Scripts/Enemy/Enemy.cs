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

    private GameObject _camera;

    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _canvas;

    private bool _canTakeDamage = true;

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
        if (!_canTakeDamage) return;
        
        _canvas.SetActive(true);

        if (_enemyStats._enemyCurrentHealth - damageTaken <= 0)
        {
            KillCharacter();
        }
        else _enemyStats._enemyCurrentHealth -= damageTaken;

        UpdateHealthBar();

        StartCoroutine(DamageCooldown());
    }

    public void KillCharacter()
    {
        Instantiate(_deathVFX, transform.position - new Vector3(0, 1, 0), transform.rotation);
        Destroy(this.gameObject);
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _enemyStats._enemyCurrentHealth / _enemyStats._enemyMaxHealth;
    }

    IEnumerator DamageCooldown()
    {
        _canTakeDamage = false;
        yield return new WaitForSeconds(0.5f);
        _canTakeDamage = true;
    }
}
