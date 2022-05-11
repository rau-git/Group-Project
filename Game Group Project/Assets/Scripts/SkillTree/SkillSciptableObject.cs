using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class SkillSciptableObject : ScriptableObject
{
    public string _skillName;
    [TextArea(1, 5)]
    public string _skillDescription;
    public int _skillCost;
    public bool _unlocked;

    public int _myIndex;
}
