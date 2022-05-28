using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Assignables")]
    [SerializeField] private Animator _animator;

    [Header("Attack Collider Assignables")]
    [SerializeField] private GameObject _swordCollider;

    [Header("Misc Assignables")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private List<BaseSkillUsage> _skillList = new List<BaseSkillUsage>();

    public int _ability1AssignedAbilityIndex;
    public int _ability2AssignedAbilityIndex;
    public int _ability3AssignedAbilityIndex;
    public int _ability4AssignedAbilityIndex;
    
    private void Awake()
    {
        
    }

    private void Start()
    {
        SwordColliderDeactivate();

        _ability1AssignedAbilityIndex = 0;
        _ability2AssignedAbilityIndex = 1;
        _ability3AssignedAbilityIndex = 2;
        _ability4AssignedAbilityIndex = 3;
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

        if (_skillList[_ability1AssignedAbilityIndex]._onCooldown) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability1AssignedAbilityIndex].UseAbility();
        StartCoroutine(AbilityCooldown(_ability1AssignedAbilityIndex, _skillList[_ability1AssignedAbilityIndex]._cooldownLength));
    }
    
    public void Ability2(Vector2 mousePosition)
    {
        if(_ability2AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        if (_skillList[_ability2AssignedAbilityIndex]._onCooldown) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability2AssignedAbilityIndex].UseAbility();
        StartCoroutine(AbilityCooldown(_ability2AssignedAbilityIndex, _skillList[_ability2AssignedAbilityIndex]._cooldownLength));
    }
    
    public void Ability3(Vector2 mousePosition)
    {
        if(_ability3AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        if (_skillList[_ability3AssignedAbilityIndex]._onCooldown) return;
        
        PlayerLookToAttack(mousePosition);
        _skillList[_ability3AssignedAbilityIndex].UseAbility();
        StartCoroutine(AbilityCooldown(_ability3AssignedAbilityIndex, _skillList[_ability3AssignedAbilityIndex]._cooldownLength));
    }
    
    public void Ability4(Vector2 mousePosition)
    {
        if(_ability4AssignedAbilityIndex + 1 > _skillList.Count) return;
        
        if (_skillList[_ability4AssignedAbilityIndex]._onCooldown) return;
    
        PlayerLookToAttack(mousePosition);
        _skillList[_ability4AssignedAbilityIndex].UseAbility();
        StartCoroutine(AbilityCooldown(_ability4AssignedAbilityIndex, _skillList[_ability4AssignedAbilityIndex]._cooldownLength));
    }

    private void SwordColliderActivate() => _swordCollider.SetActive(true);
    
    private void SwordColliderDeactivate() => _swordCollider.SetActive(false);
    
    public void StopAnimation()
    {
        _animator.SetBool("basicAttack", false);
        _animator.SetBool("samuraiAttack", false);
        _animator.SetBool("sliceAttack", false);
        _animator.SetBool("shotgunAttack", false);
    }

    private IEnumerator AbilityCooldown(int indexOfAttack, float cooldownLength)
    {
        _skillList[indexOfAttack]._onCooldown = true;
        _skillList[indexOfAttack]._myCooldownIndicator.fillAmount = 1.0f;
        yield return new WaitForSeconds(cooldownLength);
        _skillList[indexOfAttack]._onCooldown = false;
    }
}
