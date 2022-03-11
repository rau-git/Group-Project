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
    [Space(10)]

    [SerializeField] private TextMeshProUGUI _quantityUI;
    [SerializeField] private TextMeshProUGUI _useHealingItemKeybindText;
    [SerializeField] private TextMeshProUGUI _useSpinAttackKeybindText;
}
