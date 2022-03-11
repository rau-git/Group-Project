using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    private void UpgradeHealth(float amount)
    {
        _playerStats._playerMaxHealth += amount;
    }

    private void UpgradeDamage(float amount)
    {
        _playerStats._playerBaseDamage += amount;
    }
}
