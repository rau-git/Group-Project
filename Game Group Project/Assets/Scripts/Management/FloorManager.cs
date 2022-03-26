using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloorManager : MonoBehaviour
{
    [Header("Assignables")] 
    [SerializeField] private GameObject _exitDoor;
    [SerializeField] private GameObject _bossSpawnLocation;
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private GameObject _upgradeMenu;
    [SerializeField] private Collider _enemySpawnTrigger;
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameManagement _gameManagement;
    [SerializeField] private PauseManager _pauseManager;
    
    private Vector3 _playerSpawnPosition;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        _playerSpawnPosition = _player.transform.position;
        RestartLevel();
    }

    private void RestartLevel()
    {
        _enemySpawner._enemyList.Clear();
        _gameManagement.IncreaseFloor();
        _player.transform.position = _playerSpawnPosition;
        _playerAgent.enabled = false;
        _playerMovement.SetCurrentMovePosition(_player.transform.position);
        _playerAgent.enabled = true;
        Instantiate(_bossPrefab, _bossSpawnLocation.transform.position, _bossSpawnLocation.transform.rotation);
        _exitDoor.SetActive(true);
        _enemySpawnTrigger.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        RestartLevel();
        OpenPlayerUpgradeMenu();
    }

    private void OpenPlayerUpgradeMenu()
    {
        _pauseManager.SwitchPauseBool();
        _upgradeMenu.SetActive(true);
    }

    public void SetDoorStatus(bool input)
    {
        _exitDoor.SetActive(input);
    }
}
