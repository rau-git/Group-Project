using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour, IDamage<float>, IHeal<float>, IKill
{
    [Header("Assignables")]
    private PlayerStats _playerStats;
    [SerializeField] private PlayerInventoryScript _playerInventoryScript;
    [SerializeField] private GameObject _deathUI;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _deathUI.SetActive(false);
    }

    public void TakeDamage(float damageTaken)
    {
        _playerStats._playerCurrentHealth -= damageTaken;

        if (_playerStats._playerCurrentHealth <= 0)
        {
            KillCharacter();
            _playerStats._playerCurrentHealth = 0;
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

    public void LifestealFunction(float damageInput)
    {
        if(_playerStats._playerCurrentHealth >= _playerStats._playerMaxHealth) return;
        
        _playerStats._playerCurrentHealth += damageInput * (_playerStats._playerLifesteal / 100);

        if (_playerStats._playerCurrentHealth > _playerStats._playerMaxHealth)
        {
            _playerStats._playerCurrentHealth = _playerStats._playerMaxHealth;
        }
    }

    public void KillCharacter() => _deathUI.SetActive(true);
}
