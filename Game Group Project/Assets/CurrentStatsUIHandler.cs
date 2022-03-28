using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using UnityEngine;
using TMPro;

public class CurrentStatsUIHandler : MonoBehaviour
{
    [Header("Assignables")] 
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private UpgradePlayerStats _upgradePlayerStats;
    [SerializeField] private GameManagement _gameManagement;
    [SerializeField] private TextMeshProUGUI _maxHealthAmount;
    [SerializeField] private TextMeshProUGUI _maxHealthCost;
    [SerializeField] private TextMeshProUGUI _baseDamageAmount;
    [SerializeField] private TextMeshProUGUI _baseDamageCost;
    [SerializeField] private TextMeshProUGUI _currencyAmount;

    private void Start()
    {
        UpdateStatUI();
    }

    private void OnEnable()
    {
        UpdateStatUI();
    }

    public void UpdateStatUI()
    {
        _maxHealthAmount.text = _playerStats._playerMaxHealth.ToString();
        _maxHealthCost.text = "Cost: " + _upgradePlayerStats._healthUpgradeCost.ToString();
        
        _baseDamageAmount.text = _playerStats._playerBaseDamage.ToString();
        _baseDamageCost.text = "Cost: " + _upgradePlayerStats._damageUpgradeCost.ToString();
        
        _currencyAmount.text = _gameManagement._currencyCurrent.ToString();
    }
}
