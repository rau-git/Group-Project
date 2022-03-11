using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private PlayerStats _playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponentInParent<Enemy>().TakeDamage(_playerStats._playerBaseDamage);
        }
    }
}
