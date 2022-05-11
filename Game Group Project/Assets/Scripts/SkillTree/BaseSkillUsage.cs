using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseSkillUsage : MonoBehaviour
{
    public Animator _animator;
    public string _animationStringName;
    public float _activeGameObjectAttackLength;
    public float _cooldownLength;
    public bool _onCooldown;

    public enum AttackTypes
    {
        AnimationAttack,
        ActiveGameObjectAttack
    }

    public AttackTypes _attackTypes;

    private void Start()
    {
        _onCooldown = false;
        
        if (_attackTypes == AttackTypes.ActiveGameObjectAttack)
        {
            gameObject.SetActive(false);
        }
    }

    public void UseAbility()
    {
        switch (_attackTypes)
        {
            case AttackTypes.AnimationAttack:
                _animator.SetBool(_animationStringName, true);
                break;
            
            case AttackTypes.ActiveGameObjectAttack:
                gameObject.SetActive(true);
                StartCoroutine(DeactivateActiveGameObject(_activeGameObjectAttackLength));
                break;
        }
    }

    private IEnumerator DeactivateActiveGameObject(float length)
    {
        yield return new WaitForSeconds(length);
        gameObject.SetActive(false);
    }
}

