using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.Shapes;

public class FloorManager : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private GameObject _bossSpawnLocation;
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private GameObject _upgradeMenu;
    [SerializeField] private Collider _enemySpawnTrigger;
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameManagement _gameManagement;
    [SerializeField] private PauseManager _pauseManager;

    private GameObject _bossTank;

    private DoorPath _doorPath;

    private Vector3 _playerSpawnPosition;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _doorPath = GetComponent<DoorPath>();
    }

    private void Start()
    {
        _playerSpawnPosition = _player.transform.position;
        RestartLevel();
    }

    public void RestartLevel()
    {
        _gameManagement.IncreaseFloor();
        _enemySpawner._enemyList.Clear();
        _enemySpawner.DestroyAllEnemies();
        Destroy(_bossTank);
        _doorPath.OpenPath();
        _player.transform.position = _playerSpawnPosition;
        _playerAgent.enabled = false;
        _bossTank = Instantiate(_bossPrefab, _bossSpawnLocation.transform.position, _bossSpawnLocation.transform.rotation);
        _playerMovement.SetCurrentMovePosition(_player.transform.position);
        _playerAgent.enabled = true;
        
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
}
