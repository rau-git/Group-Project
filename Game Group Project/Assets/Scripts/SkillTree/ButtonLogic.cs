using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ButtonLogic : MonoBehaviour
{
    public SkillSciptableObject _mySkill;
    private Image _image;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();

        _text.text = _mySkill._skillName;
    }
}
