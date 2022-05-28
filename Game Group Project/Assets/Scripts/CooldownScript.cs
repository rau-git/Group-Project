using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScript : MonoBehaviour
{
    public bool _runCooldown;
    private Image _image;
    private float _cooldownLength;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (_runCooldown = false) return;

        _image.fillAmount = 1.0f;
        _image.fillAmount -= 1.0f / _cooldownLength * Time.deltaTime;
    }
}
