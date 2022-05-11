using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private PlayerStats _playerStats;
    private Enemy _enemy;
    private Rigidbody _rigidbody;   
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * 2000);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("DamageObject")) return;
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_playerStats._playerBaseDamage / 4);
            Destroy(gameObject);
        }

        if (!other.gameObject.CompareTag("Player") || !other.gameObject.CompareTag("DamageObject"))
        {
            Destroy(gameObject);
        }
    }
}
