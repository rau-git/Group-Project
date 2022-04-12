using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerInput : MonoBehaviour
{
    [Header("Scripts Input Controls")]
    private PlayerMovement _playerMovementScript;
    private PlayerAttack _playerAttackScript;

    private InputControls _inputControls;

    private void Awake()
    {
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
        if (_inputControls.Player.Dodge.triggered)
        {
            _playerMovementScript.Dodge();
        }
        if (_inputControls.Player.PrimaryAttack.triggered)
        {
            _playerAttackScript.BasicAttack(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        if (_inputControls.Player.Ability1.triggered)
        {
            _playerAttackScript.Ability1(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        if (_inputControls.Player.Ability2.triggered)
        {
            _playerAttackScript.Ability2(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        if (_inputControls.Player.Ability3.triggered)
        {
            _playerAttackScript.Ability3(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        if (_inputControls.Player.Ability4.triggered)
        {
            _playerAttackScript.Ability4(_inputControls.Player.MousePosition.ReadValue<Vector2>());
        }
        
    }
        
}
