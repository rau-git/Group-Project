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
    [SerializeField] private Collider _enemySpawnTrigger;
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private EnemySpawner _enemySpawner;
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
        _enemySpawnTrigger.enabled = true;
        _playerAgent.enabled = false;
        _player.transform.position = _playerSpawnPosition;
        _playerAgent.enabled = true;
        _exitDoor.SetActive(true);
        Instantiate(_bossPrefab, _bossSpawnLocation.transform.position, _bossSpawnLocation.transform.rotation);
        _enemySpawner._enemyList.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestartLevel();
        }
    }

    public void SetDoorStatus(bool input)
    {
        _exitDoor.SetActive(input);
    }
}
