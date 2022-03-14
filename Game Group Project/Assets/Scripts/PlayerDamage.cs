using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private PlayerStats _playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponentInParent<Enemy>().TakeDamage(_playerStats._playerBaseDamage);
            Debug.Log("I have damaged: " + other.gameObject.name + " for " + _playerStats._playerBaseDamage);
        }
    }
}
