using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour, IDamage<float>, IHeal<float>, IKill
{
    [Header("Assignables")]
    private PlayerStats _playerStats;
    [SerializeField] private PlayerInventoryScript _playerInventoryScript;
    
    private void Awake() => _playerStats = GetComponent<PlayerStats>();

    public void TakeDamage(float damageTaken)
    {
        Mathf.Clamp(_playerStats._playerCurrentHealth -= damageTaken, 0, _playerStats._playerMaxHealth);

        if (_playerStats._playerCurrentHealth <= 0)
        {
            KillCharacter();
        }
    }

    public void HealCharacter(float healAmount)
    {
        if (_playerStats._playerCurrentHealth >= _playerStats._playerMaxHealth) return;

        _playerInventoryScript._healingItem._itemQuantity -= 1;
        _playerStats._playerCurrentHealth += healAmount;

        if (_playerStats._playerCurrentHealth > _playerStats._playerMaxHealth)
        {
            _playerStats._playerCurrentHealth = _playerStats._playerMaxHealth;
        }
    }

    public void KillCharacter() => Debug.Log("Character is dead! :C");
}
