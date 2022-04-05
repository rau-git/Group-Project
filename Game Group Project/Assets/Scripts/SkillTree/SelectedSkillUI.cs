using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectedSkillUI : MonoBehaviour
{
    public TextMeshProUGUI _selectedSkillName;
    public TextMeshProUGUI _selectedSkillDescription;
    public TextMeshProUGUI _selectedSkillCost;
    public GameObject _selectedSkillUnlockStatus;

    public SkillSciptableObject _selectedSkill;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void SetSelectedSkill(SkillSciptableObject setSkill)
    {
        this.gameObject.SetActive(true);
        _selectedSkill = setSkill;
        ShowSkillDescription();
    }

    private void ShowSkillDescription()
    {
        _selectedSkillName.text = _selectedSkill._skillName;
        _selectedSkillDescription.text = _selectedSkill._skillDescription;
        _selectedSkillCost.text = "Cost: " + _selectedSkill._skillCost.ToString();
        _selectedSkillUnlockStatus.SetActive(_selectedSkill._unlocked);
    }
}
