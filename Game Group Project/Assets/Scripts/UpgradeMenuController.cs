using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenuController : MonoBehaviour
{
    [Header("Scripts to Reference")] 
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private UpgradePlayerStats _upgradePlayerStats;
    [SerializeField] private GameManagement _gameManagement;
    
    [Space(30)]
    
    [Header("Upgrade Stats Assign")] 
    [SerializeField] private TextMeshProUGUI _maxHealthIncreaseAmount;
    [SerializeField] private TextMeshProUGUI _baseDamageIncreaseAmount;
    [SerializeField] private TextMeshProUGUI _lifestealIncreaseAmount;
    [SerializeField] private TextMeshProUGUI _difficultyIncreaseAmount;
    
    [Space(15)]
    
    [SerializeField] private TextMeshProUGUI _maxHealthUpgradeCost;
    [SerializeField] private TextMeshProUGUI _baseDamageUpgradeCost;
    [SerializeField] private TextMeshProUGUI _lifestealUpgradeCost;
    [SerializeField] private TextMeshProUGUI _difficultyUpgradeCost;
    
    [Space(30)]
    
    [Header("Current Stats Assign")]
    [SerializeField] private TextMeshProUGUI _maxHealthCurrentAmount;
    [SerializeField] private TextMeshProUGUI _baseDamageCurrentAmount;
    [SerializeField] private TextMeshProUGUI _lifestealCurrentAmount;
    [SerializeField] private TextMeshProUGUI _difficultyCurrentAmount;
    [SerializeField] private TextMeshProUGUI _currencyCurrentAmount;

    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        _maxHealthIncreaseAmount.text = "+" + _upgradePlayerStats._healthUpgradeAmount.ToString();
        _baseDamageIncreaseAmount.text = "+" + _upgradePlayerStats._damageUpgradeAmount.ToString();
        _lifestealIncreaseAmount.text = "+" + _upgradePlayerStats._lifestealUpgradeAmount.ToString() + "%";
        _difficultyIncreaseAmount.text = "+" + _upgradePlayerStats._difficultyUpgradeAmount.ToString() + "x";

        _maxHealthUpgradeCost.text = _upgradePlayerStats._healthUpgradeCost.ToString() + " sc";
        _baseDamageUpgradeCost.text = _upgradePlayerStats._damageUpgradeCost.ToString() + " sc";
        _lifestealUpgradeCost.text = _upgradePlayerStats._lifestealUpgradeCost.ToString() + " sc";
        _difficultyUpgradeCost.text = _upgradePlayerStats._difficultyUpgradeCost.ToString() + " sc";

        _maxHealthCurrentAmount.text = _playerStats._playerMaxHealth.ToString();
        _baseDamageCurrentAmount.text = _playerStats._playerBaseDamage.ToString();
        _lifestealCurrentAmount.text = _playerStats._playerLifesteal.ToString() + "%";
        _difficultyCurrentAmount.text = _gameManagement._currentDifficulty.ToString() + "x";
        _currencyCurrentAmount.text = _gameManagement._currencyCurrent.ToString() + " sc";
    }
}
