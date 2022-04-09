using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Assignables")]
    [SerializeField] private Animator _animator;

    [Header("Attack Collider Assignables")]
    [SerializeField] private GameObject _slamAttackCollider;
    [SerializeField] private GameObject _spinAttackCollider;
    [SerializeField] private GameObject _basicAttackCollider;

    [Header("Misc Assignables")]
    [SerializeField] private Camera _playerCamera;

    [Header("Actions")] 
    private Action _ability1;
    private Action _ability2;
    private Action _ability3;
    private Action _ability4;

    private void Awake()
    {
        SlamAttackColliderDeactivate();
        SpinAttackColliderDeactivate();
        BasicAttackColliderDeactivate();
    }

    private void PlayerLookToAttack()
    {
        var ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out var hit);

        var lookAtPos = hit.point;
        lookAtPos.y = transform.position.y;

        transform.LookAt(lookAtPos);
    }

    public void SetAbility1(Action inputAbility) => _ability1 = inputAbility;

    public void SetAbility2(Action inputAbility) => _ability2 = inputAbility;

    public void SetAbility3(Action inputAbility) => _ability3 = inputAbility;

    public void SetAbility4(Action inputAbility) => _ability4 = inputAbility;

    public void Ability1() => _ability1();

    public void Ability2() => _ability2();

    public void Ability3() => _ability3();

    public void Ability4() => _ability4();

    public void BasicAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("basicAttack", true);
    }

    public void SpinAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("spinAttack", true);
    }

    public void SlamAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("slamAttack", true);
    }
    
    private void BasicAttackColliderActivate() => _basicAttackCollider.SetActive(true);

    private void BasicAttackColliderDeactivate() => _basicAttackCollider.SetActive(false);
    
    private void SpinAttackColliderActivate() => _spinAttackCollider.SetActive(true);
    
    private void SpinAttackColliderDeactivate() => _spinAttackCollider.SetActive(false);
    
    private void SlamAttackColliderActivate() => _slamAttackCollider.SetActive(true);

    private void SlamAttackColliderDeactivate() => _slamAttackCollider.SetActive(false);
    
    public void StopAnimation()
    {
        _animator.SetBool("basicAttack", false);
        _animator.SetBool("spinAttack", false);
        _animator.SetBool("slamAttack", false);
    }
}
