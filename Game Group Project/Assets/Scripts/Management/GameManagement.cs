using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [Header("Current Game Tracking Variables")]
    public int _currentPlayerFloor;
    public float _currentDifficulty;


    [Header("Statistics Tracking")] 
    public int _enemiesKilled;
    public int _bossesKilled;
    public int _currencyGatheredTotal;
    public int _currencyCurrent;
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
}
    
