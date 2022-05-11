using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerStats : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameManagement _gameManagement;

    [Header("Upgrade Amounts")] 
    public float _healthUpgradeAmount;
    public float _damageUpgradeAmount;
    public float _lifestealUpgradeAmount;
    public float _difficultyUpgradeAmount;
    
    [Space(20)]
    
    [Header("Upgrade Costs")] 
    public int _healthUpgradeCost;
    public int _damageUpgradeCost;
    public int _lifestealUpgradeCost;
    public int _difficultyUpgradeCost;

    private void Awake() => _playerStats = GetComponent<PlayerStats>();

    public void UpgradeHealth()
    {
        if (_gameManagement._currencyCurrent < _healthUpgradeCost) return;
        
        _playerStats._playerMaxHealth += _healthUpgradeAmount;
        _gameManagement._currencyCurrent -= _healthUpgradeCost;
        _healthUpgradeCost = Mathf.RoundToInt(_healthUpgradeCost * 1.05f);
    }

    public void UpgradeDamage()
    {
        if (_gameManagement._currencyCurrent < _damageUpgradeCost) return; 
        
        _playerStats._playerBaseDamage += _damageUpgradeAmount;
        _gameManagement._currencyCurrent -= _damageUpgradeCost;
        _damageUpgradeCost = Mathf.RoundToInt(_damageUpgradeCost * 1.05f);
    }

    public void UpgradeLifesteal()
    {
        if (_gameManagement._currencyCurrent < _lifestealUpgradeCost) return;

        _playerStats._playerLifesteal += _lifestealUpgradeAmount;
        _gameManagement._currencyCurrent -= _lifestealUpgradeCost;
        _lifestealUpgradeCost = Mathf.RoundToInt(_lifestealUpgradeCost * 1.05f);
    }
    
    public void UpgradeDifficulty()
    {
        if (_gameManagement._currencyCurrent < _difficultyUpgradeCost) return;

        _playerStats._playerDifficulty += _difficultyUpgradeAmount;
        _gameManagement._currencyCurrent -= _difficultyUpgradeCost;
        _difficultyUpgradeCost = Mathf.RoundToInt(_difficultyUpgradeCost * 1.05f);
    }
}
