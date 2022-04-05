using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class SkillSciptableObject : ScriptableObject
{
    public string _skillName;
    [TextArea(1, 5)]
    public string _skillDescription;
    public int _skillCost;
    public bool _unlocked;
    public bool _available;
    public List<SkillSciptableObject> _dependentSkills = new List<SkillSciptableObject>();

    public void SetDependentsEnabled()
    {
        foreach (var dependentSkill in _dependentSkills)
        {
            dependentSkill._available = true;
        }
    }
}
