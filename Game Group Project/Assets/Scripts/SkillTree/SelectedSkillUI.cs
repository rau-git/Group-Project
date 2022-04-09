using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectedSkillUI : MonoBehaviour
{
    [SerializeField] private GameManagement _gameManagement;
    
    public TextMeshProUGUI _selectedSkillName;
    public TextMeshProUGUI _selectedSkillDescription;
    public TextMeshProUGUI _selectedSkillCost;
    
    public GameObject _selectedSkillUnlockStatus;
    public GameObject _selectedSkillCostGameObject;
    public GameObject _selectedSkillAssignObject;

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
        
        CheckHiddenObjects();
    }

    private void CheckHiddenObjects()
    {
        _selectedSkillUnlockStatus.SetActive(_selectedSkill._unlocked);
        _selectedSkillCostGameObject.SetActive(!_selectedSkill._unlocked);
        _selectedSkillAssignObject.SetActive(_selectedSkill._unlocked);
    }

    public void BuySelectedSkill()
    {
        if (_gameManagement._currencyCurrent < _selectedSkill._skillCost) return;

        _gameManagement._currencyCurrent -= _selectedSkill._skillCost;
        _selectedSkill._unlocked = true;
        ShowSkillDescription();
    }
}
