using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerInput : MonoBehaviour
{
    [Header("Scripts Input Controls")]
    private PlayerInventoryScript _playerHealingInventoryScript;
    private PlayerMovement _playerMovementScript;
    private PlayerAttack _playerAttackScript;

    private void Awake()
    {
        _playerHealingInventoryScript = GetComponent<PlayerInventoryScript>();
        _playerMovementScript = GetComponent<PlayerMovement>();
        _playerAttackScript = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetButton("MoveCharacter"))
        {
            _playerMovementScript.GetInput();
        }
        if (Input.GetButtonDown("UseHealingItem"))
        {
            _playerHealingInventoryScript.UseItem();
        }
        if (Input.GetButton("PrimaryAttack"))
        {
            _playerAttackScript.BasicAttack();
        }
        if (Input.GetButton("SpinAttack"))
        {
            _playerAttackScript.SpinAttack();
        }
        if (Input.GetButton("SlamAttack"))
        {
            _playerAttackScript.SlamAttack();
        }
    }
} 
