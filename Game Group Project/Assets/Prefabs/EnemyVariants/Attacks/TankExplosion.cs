using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankExplosion : MonoBehaviour
{
    [SerializeField] private GameObject _initialTargetVFX;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Collider _myCollider; 
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private List<AudioClip> _audioClips;
    
    private PlayerFunctions _playerFunctions;

    [SerializeField] private float _timeBeforeExplosion;

    private void Awake()
    {
        _myCollider = GetComponent<Collider>();
        _playerFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFunctions>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        _initialTargetVFX.SetActive(true);
        _explosionPrefab.SetActive(false);
        _myCollider.enabled = false;

        _audioSource.clip = _audioClips[UnityEngine.Random.Range(0, _audioClips.Count)];

        var positionToLand = new Vector3(_player.transform.position.x, 0.01f, _player.transform.position.z);
        transform.position = positionToLand;

        StartCoroutine(StartExplosion());
    }

    private IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(_timeBeforeExplosion);
        _explosionPrefab.SetActive(true);
        _myCollider.enabled = true;
        Destroy(gameObject, 0.5f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _playerFunctions.TakeDamage(_enemyStats._enemyBaseDamage);
    }
}
