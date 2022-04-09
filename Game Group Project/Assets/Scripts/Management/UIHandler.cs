using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private ItemObject _itemObject;
    [SerializeField] private PlayerStats _playerStats;
    [Space(10)]

    [SerializeField] private Image _playerHealthbar;
    [SerializeField] private TextMeshProUGUI _playerHealthPercentage;
    [Space(10)]

    [SerializeField] private TextMeshProUGUI _quantityUI;
    [SerializeField] private TextMeshProUGUI _useHealingItemKeybindText;
    [SerializeField] private TextMeshProUGUI _useSpinAttackKeybindText;

    private void Update()
    {
        float playerHealth = _playerStats._playerCurrentHealth / _playerStats._playerMaxHealth;
        _playerHealthbar.fillAmount = playerHealth;
        _playerHealthPercentage.text = Mathf.RoundToInt(playerHealth * 100).ToString() + "%";
    }
}
