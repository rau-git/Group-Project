using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerStats : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameManagement _gameManagement;

    [Header("Costs")] 
    public int _healthUpgradeCost;
    public int _damageUpgradeCost;

    private void Awake() => _playerStats = GetComponent<PlayerStats>();

    private void Start()
    {
        _healthUpgradeCost = 25;
        _damageUpgradeCost = 50;
    }

    public void UpgradeHealth(float amount)
    {
        if (_gameManagement._currencyCurrent < _healthUpgradeCost) return;
        
        _playerStats._playerMaxHealth += amount;
        _gameManagement._currencyCurrent -= _healthUpgradeCost;
        _healthUpgradeCost = Mathf.RoundToInt(_healthUpgradeCost * 1.05f);
    }

    public void UpgradeDamage(float amount)
    {
        if (_gameManagement._currencyCurrent < _damageUpgradeCost) return; 
        
        _playerStats._playerBaseDamage += amount;
        _gameManagement._currencyCurrent -= _damageUpgradeCost;
        _damageUpgradeCost = Mathf.RoundToInt(_damageUpgradeCost * 1.05f);
    }
}
