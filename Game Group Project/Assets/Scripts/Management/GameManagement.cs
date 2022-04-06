using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [Header("Assignables")] 
    [SerializeField] private FloorManager _floorManager;
    [SerializeField] private PlayerStats _playerStats;
    
    [Header("Current Game Tracking Variables")]
    public int _currentPlayerFloor;
    public float _currentDifficulty;
    public int _currencyCurrent;

    [Header("Statistics Tracking")] 
    public int _enemiesKilled;
    public int _bossesKilled;
    public int _currencyGatheredTotal;
    public int _currencySpent;
    public int _highestFloor;

    public void Awake()
    {
        _currentPlayerFloor = 0;
        _currentDifficulty = 0;
        _enemiesKilled = 0;
        _bossesKilled = 0;
        _currencyGatheredTotal = 0;
        _currencyCurrent = 0;
        _currencySpent = 0;
        _highestFloor = 0;
    }

    public void IncreaseFloor()
    {
        _currentPlayerFloor += 1;
        _currentDifficulty = 1 + _currentPlayerFloor * 0.1f;
    }

    public void RestartGame()
    {
        _currentPlayerFloor = 0;
        _currentDifficulty = 0;
        _enemiesKilled = 0;
        _bossesKilled = 0;
        _currencyGatheredTotal = 0;
        _currencyCurrent = 0;
        _currencySpent = 0;
        _highestFloor = 0;
        
        _playerStats._playerCurrentHealth = _playerStats._playerMaxHealth;
        _floorManager.RestartLevel();
    }
}
    
