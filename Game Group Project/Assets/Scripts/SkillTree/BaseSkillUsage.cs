using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkillUsage : MonoBehaviour
{
    public Animator _animator;
    public string _animationStringName;

    public void UseAbility()
    {
        _animator.SetBool(_animationStringName, true);
    }
}
