using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerInput : MonoBehaviour
{
    [Header("Scripts Input Controls")]
    private PlayerInventoryScript _playerHealingInventoryScript;
    private PlayerMovement _playerMovementScript;
    private PlayerAttack _playerAttackScript;

    private InputControls _inputControls;

    private void Awake()
    {
        _playerHealingInventoryScript = GetComponent<PlayerInventoryScript>();
        _playerMovementScript = GetComponent<PlayerMovement>();
        _playerAttackScript = GetComponent<PlayerAttack>();
        
        _inputControls = new InputControls();
        _inputControls.Enable();
    }

    private void OnEnable()
    {
        _inputControls.Enable();
    }

    private void OnDisable()
    {
        _inputControls.Disable();
    }

    private void Update()
    {
        if (_inputControls.Player.MoveCharacter.IsPressed())
        {
            _playerMovementScript.GetInput(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        /*
        if (Input.GetButtonDown("Dodge"))
        {
            _playerMovementScript.Dodge();
        }
        if (Input.GetButtonDown("PrimaryAttack"))
        {
            _playerAttackScript.BasicAttack();
        }
        if (Input.GetButtonDown("SpinAttack"))
        {
            _playerAttackScript.SpinAttack();
        }
        if (Input.GetButtonDown("SlamAttack"))
        {
            _playerAttackScript.SlamAttack();
        }
        */
    }
        
}
