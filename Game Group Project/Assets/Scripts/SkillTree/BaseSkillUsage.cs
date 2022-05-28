using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkillUsage : MonoBehaviour
{
    public Animator _animator;
    public string _animationStringName;
    public float _activeGameObjectAttackLength;
    public Collider _collider;
    public float _cooldownLength;
    public bool _onCooldown;
    public Image _myCooldownIndicator;

    public enum AttackTypes
    {
        AnimationAttack,
        ActiveGameObjectAttack
    }

    public AttackTypes _attackTypes;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

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
                _collider.enabled = true;
                StartCoroutine(DeactivateCollider(_activeGameObjectAttackLength));
                StartCoroutine(DeactivateActiveGameObject(_cooldownLength));
                break;
        }
    }

    private void Update()
    {
        if (!_onCooldown) return;
        
       _myCooldownIndicator.fillAmount -= 1.0f / _cooldownLength * Time.deltaTime;
    }

    private IEnumerator DeactivateActiveGameObject(float length)
    {
        yield return new WaitForSeconds(length);
        gameObject.SetActive(false);
    }

    private IEnumerator DeactivateCollider(float length)
    {
        yield return new WaitForSeconds(length);
        _collider.enabled = false;
    }
}

