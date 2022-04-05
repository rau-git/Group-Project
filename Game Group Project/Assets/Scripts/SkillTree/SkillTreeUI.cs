using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    [Header("Skill Tree Branches")] 
    [SerializeField] private GameObject _meleeMenu;
    [SerializeField] private GameObject _rangedMenu;
    [SerializeField] private GameObject _defenseMenu;
    [SerializeField] private GameObject _specialMenu;

    [SerializeField] private TextMeshProUGUI _dropDownReference;

    private void Awake()
    {
        MeleeMenuActive();
    }

    public void SetMenu()
    {
        switch (_dropDownReference.text)
        {
            case "Melee Skills":
                MeleeMenuActive();
                break;
            case "Ranged Skills":
                RangedMenuActive();
                break;
            case "Defense Skills":
                DefenseMenuActive();
                break;
            case "Special Skills":
                SpecialMenuActive();
                break;
        }

        if (_dropDownReference.text == "Melee Skills")
        {
            
        }
    }

    private void MeleeMenuActive()
    {
        _meleeMenu.SetActive(true);
        _rangedMenu.SetActive(false);
        _defenseMenu.SetActive(false);
        _specialMenu.SetActive(false);
    }

    private void RangedMenuActive()
    {
        _meleeMenu.SetActive(false);
        _rangedMenu.SetActive(true);
        _defenseMenu.SetActive(false);
        _specialMenu.SetActive(false);
    }
    
    private void DefenseMenuActive()
    {
        _meleeMenu.SetActive(false);
        _rangedMenu.SetActive(false);
        _defenseMenu.SetActive(true);
        _specialMenu.SetActive(false);
    }
    
    private void SpecialMenuActive()
    {
        _meleeMenu.SetActive(false);
        _rangedMenu.SetActive(false);
        _defenseMenu.SetActive(false);
        _specialMenu.SetActive(true);
    }

}
