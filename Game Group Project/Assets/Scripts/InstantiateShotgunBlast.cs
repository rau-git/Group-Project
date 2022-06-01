using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class InstantiateShotgunBlast : MonoBehaviour
{
    private PlayerStats _playerStats;
    
    [SerializeField] private GameObject _targetGameObject;
    [SerializeField] private GameObject _shotgunBulletSpawnPoint;
    [SerializeField] private InputControls _inputControls;
    [SerializeField] private GameObject _originalTargetPosition;

    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;

    private void Awake()
    {
        _inputControls = new InputControls();
        _audioSource = GetComponent<AudioSource>();
        _playerStats = GetComponent<PlayerStats>();
    }

    public void GetEnemyPosition()
    {
        var maxDistance  = 10f;
        var currentClosestDistance = maxDistance;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        var worldPos = hit.point;
            
        
        worldPos = new Vector3(worldPos.x, 0, worldPos.z);
        
        var colliders = Physics.OverlapSphere(worldPos, maxDistance);
        Collider cachedEnemyCollider = null;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                if (Vector3.Distance(worldPos, collider.transform.position) < currentClosestDistance)
                {
                    currentClosestDistance = Vector3.Distance(worldPos, collider.transform.position);
                    cachedEnemyCollider = collider;
                }
            }
        }

        if (cachedEnemyCollider == null) return;
        
        _targetGameObject.transform.position = new Vector3(cachedEnemyCollider.transform.position.x, cachedEnemyCollider.transform.position.y + 1f ,cachedEnemyCollider.transform.position.z);

        StartCoroutine(WaitToMoveBack());
    }

    private IEnumerator WaitToMoveBack()
    {
        yield return new WaitForSeconds(1f);
        _targetGameObject.transform.position = _originalTargetPosition.transform.position;
    }

    public void Shoot()
    {
        RaycastHit hit;

        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Count)];
        _audioSource.Play();
        
        _shotgunBulletSpawnPoint.transform.LookAt(_targetGameObject.transform.position);

        if (Physics.Raycast(_shotgunBulletSpawnPoint.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(_playerStats._playerBaseDamage);
            }
        }
    }
}
