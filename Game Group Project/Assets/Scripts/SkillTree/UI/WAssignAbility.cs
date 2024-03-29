using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAssignAbility : MonoBehaviour
{
    [SerializeField] private SelectedSkillUI _selectedSkillUI;
    [SerializeField] private PlayerAttack _playerAttack;
    
    private SkillSciptableObject _mySkill;

    public void SetSkill()
    {
        _mySkill = _selectedSkillUI._selectedSkill;

        _playerAttack._ability2AssignedAbilityIndex = _mySkill._myIndex;
    }
}
