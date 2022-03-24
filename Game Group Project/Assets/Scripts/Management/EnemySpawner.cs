using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MiscUtil.Linq.Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] List<GameObject> _enemyTypes;
    [Space(20)]

    [Header("Spawn Values")]
    [SerializeField] private int _spawnAmount;
    [Range(1, 100)] 
    [SerializeField] private float _spawnRange;
    [Space(20)]

    [Header("Spawn Bounds")]
    [SerializeField] private Vector3 bounds;
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    [SerializeField] private float zBounds;

    [Header("Assignables")] 
    [SerializeField] private FloorManager _floorManager;
    [SerializeField] private GameManagement _gameManagement;
    
    private Collider _myCollider;

    public List<GameObject> _enemyList = new List<GameObject>();

    private void Awake()
    {
        _myCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        RemoveNullElements();
        CheckEnemyCount();
    }

    private void RemoveNullElements() => _enemyList.RemoveAll(listObject => listObject == null);

    private void CheckEnemyCount() => _floorManager.SetDoorStatus(_enemyList.Count > 0);

    [ContextMenu("Populate")]
    public void PopulateNavmesh()
    {
        foreach (GameObject enemy in _enemyTypes)
        {
            for (int i = 0; i < _spawnAmount / _enemyTypes.Capacity; i++)
            {
                GameObject instantiatedObject = Instantiate(enemy, GetRandomPosition(), Quaternion.Euler(0, Random.Range(0, 360), 0));
                _enemyList.Add(instantiatedObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        PopulateNavmesh();
        _myCollider.enabled = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-xBounds / 2, xBounds / 2), Random.Range(-yBounds / 2, yBounds / 2), Random.Range(-zBounds / 2, zBounds / 2));

        NavMesh.SamplePosition(randomPosition, out var hit, _spawnRange, NavMesh.AllAreas);
        
        Vector3 spawnPosition = hit.position;

        return spawnPosition;
    }

    [ContextMenu("Set Bounds")]
    private void SetBounds() => bounds = new Vector3(xBounds, yBounds, zBounds);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, bounds);
    }
}
