using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour, IDamage<float>, IHeal<float>, IKill
{
    [Header("Assignables")]
    private PlayerStats _playerStats;

    private void Awake() => _playerStats = GetComponent<PlayerStats>();

    public void TakeDamage(float damageTaken)
    {
        Mathf.Clamp(_playerStats._playerCurrentHealth -= damageTaken, 0, _playerStats._playerMaxHealth);

        if (_playerStats._playerCurrentHealth <= 0)
        {
            KillCharacter();
        }
    }

    public void HealCharacter(float healAmount) => Mathf.Clamp(_playerStats._playerCurrentHealth += healAmount, 0, _playerStats._playerMaxHealth);

    public void KillCharacter() => Debug.Log("Character is dead! :C");
}
