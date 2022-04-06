using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;

public class DeathScreenUIHandler : MonoBehaviour
{
    [Header("Assignables")] 
    [SerializeField] private TextMeshProUGUI _enemyDeadText;
    [SerializeField] private PauseManager _pauseManager;
    [SerializeField] private GameManagement _gameManagement;
    
    private void OnEnable()
    {
        _pauseManager.SwitchPauseBool();
        _enemyDeadText.text = "you did kill " + _gameManagement._enemiesKilled.ToString() + " goons and got to floor " + _gameManagement._currentPlayerFloor + " tho nice nice nice nice nice nice nice";
    }
}
