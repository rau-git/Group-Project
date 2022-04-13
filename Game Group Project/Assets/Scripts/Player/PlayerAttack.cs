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
    [SerializeField] private List<BaseSkillUsage> _skillList = new List<BaseSkillUsage>();

    public int _ability1AssignedAbilityIndex;
    public int _ability2AssignedAbilityIndex;
    public int _ability3AssignedAbilityIndex;
    public int _ability4AssignedAbilityIndex;
    
    private void Awake()
    {
        SlamAttackColliderDeactivate();
        SpinAttackColliderDeactivate();
        BasicAttackColliderDeactivate();
    }

    private void PlayerLookToAttack(Vector2 mousePosition)
    {
        var ray = _playerCamera.ScreenPointToRay(mousePosition);
        
        Physics.Raycast(ray, out var hit);

        var lookAtPos = hit.point;
        lookAtPos.y = transform.position.y;

        transform.LookAt(lookAtPos);
    }

    public void BasicAttack(Vector2 mousePosition)
    {
        PlayerLookToAttack(mousePosition);
        _animator.SetBool("basicAttack", true);
    }

    public void Ability1(Vector2 mousePosition)
    {
        if(_ability1AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability1AssignedAbilityIndex].UseAbility();
    }
    
    public void Ability2(Vector2 mousePosition)
    {
        if(_ability2AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability2AssignedAbilityIndex].UseAbility();
    }
    
    public void Ability3(Vector2 mousePosition)
    {
        if(_ability3AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability3AssignedAbilityIndex].UseAbility();
    }
    
    public void Ability4(Vector2 mousePosition)
    {
        if(_ability4AssignedAbilityIndex + 1 > _skillList.Count) return;
    
        PlayerLookToAttack(mousePosition);
        _skillList[_ability4AssignedAbilityIndex].UseAbility();
    }
    
    public void SpinAttack(Vector2 mousePosition)
    {
        PlayerLookToAttack(mousePosition);
        _animator.SetBool("spinAttack", true);
    }

    public void SlamAttack(Vector2 mousePosition)
    {
        PlayerLookToAttack(mousePosition);
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
