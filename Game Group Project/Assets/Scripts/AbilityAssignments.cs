using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityAssignments : MonoBehaviour
{
    public SkillSciptableObject _mySkill;
    public KeyCode _myKeyCode;

    private void SetKey(SkillSciptableObject inputSkill)
    {
        _mySkill._skillButton = KeyCode.None;
        _mySkill = inputSkill;
        _mySkill._skillButton = _myKeyCode;
    }
}
