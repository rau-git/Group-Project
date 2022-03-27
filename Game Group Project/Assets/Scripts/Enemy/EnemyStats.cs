using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public float _enemyCurrentHealth;
    public float _enemyMaxHealth;
    public float _enemyBaseDamage;
    public float _enemyVisionRange;
    public float _enemyAttackRange;

    private void Awake()
    {
        _enemyCurrentHealth = 100;
        _enemyMaxHealth = 100;
        _enemyBaseDamage = 1;
        _enemyVisionRange = 20;
        _enemyAttackRange = 3;
    }
}
