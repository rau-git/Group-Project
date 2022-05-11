using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float _damageMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponentInParent<Enemy>().TakeDamage(_playerStats._playerBaseDamage * _damageMultiplier);
        }
    }
}
