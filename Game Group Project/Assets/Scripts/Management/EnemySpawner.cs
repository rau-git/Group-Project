using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")] [SerializeField]
    List<GameObject> _enemyTypes;

    [Space(20)] [Header("Spawn Values")] [SerializeField]
    private Vector2 _defaultSpawnAmount;

    [Range(1, 1000)] [SerializeField] private float _spawnRange;

    [Space(20)] [Header("Spawn Bounds")] [SerializeField]
    private Vector3 bounds;

    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    [SerializeField] private float zBounds;

    [Header("Assignables")] [SerializeField]
    private FloorManager _floorManager;

    [SerializeField] private GameManagement _gameManagement;

    private Collider _myCollider;

    public List<GameObject> _enemyList;

    private void Awake()
    {
        _myCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        RemoveNullElements();
    }

    private void RemoveNullElements() => _enemyList.RemoveAll(listObject => listObject == null);

    [ContextMenu("Populate")]
    public void PopulateNavmesh()
    {
        int _spawnAmount = Mathf.RoundToInt(Random.Range(_defaultSpawnAmount.x, _defaultSpawnAmount.y) *
                                            _gameManagement._currentDifficulty);

        foreach (GameObject enemy in _enemyTypes)
        {
            for (int i = 0; i < _spawnAmount / _enemyTypes.Capacity; i++)
            {
                GameObject instantiatedObject = Instantiate(enemy, GetRandomPosition(),
                    Quaternion.Euler(0, Random.Range(0, 360), 0));
                instantiatedObject.transform.SetParent(this.transform);
                _enemyList.Add(instantiatedObject);
            }
        }
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
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
