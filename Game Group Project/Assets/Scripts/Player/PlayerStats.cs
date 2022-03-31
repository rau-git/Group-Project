using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Attributes")]
    public float _playerCurrentHealth;
    public float _playerMaxHealth;
    public float _playerBaseDamage;
    public float _dodgeDistance;

    [Header("Cooldowns")] 
    public float _dodgeCooldown;
    public float _slamCooldown;
    public float _spinCooldown;

    public void UpgradeMaxHealth(float increaseValue)
    {
        _playerMaxHealth += increaseValue;
    }

    public void UpgradeBaseDamage(float increaseValue)
    {
        _playerBaseDamage += increaseValue;
    }
}
