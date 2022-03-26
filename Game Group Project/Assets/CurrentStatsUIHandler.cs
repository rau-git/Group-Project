using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using UnityEngine;
using TMPro;

public class CurrentStatsUIHandler : MonoBehaviour
{
    [Header("Assignables")] 
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private TextMeshProUGUI _maxHealthAmount;
    [SerializeField] private TextMeshProUGUI _baseDamageAmount;

    private void Start()
    {
        UpdateStatUI();
    }

    public void UpdateStatUI()
    {
        _maxHealthAmount.text = _playerStats._playerMaxHealth.ToString();
        _baseDamageAmount.text = _playerStats._playerBaseDamage.ToString();
    }
}
