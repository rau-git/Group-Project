using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerMaterial : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private Material _playerEmissiveMaterial;
    [SerializeField] private Toggle _toggleRainbow;
    [SerializeField] private Slider _hueSlider;
    [SerializeField] private Slider _saturationSlider;
    [SerializeField] private Slider _rainbowSpeedSlider;
    
    [Header("Values")]
    private float _rainbowSpeed;
    private float _rainbowHueValue;
    private bool _rainbowModeBool;

    private void Awake()
    {
        _hueSlider.value = 0.0f;
        _saturationSlider.value = 1.0f;
        _toggleRainbow.isOn = false;

        _rainbowSpeed = 0.1f;
        _rainbowHueValue = 0.0f;
    }

    private void FixedUpdate()
    {
        if (!_rainbowModeBool) return;

        RainbowMode();
    }

    public void OnChange()
    {
        if (_rainbowModeBool) return;
        
        _playerEmissiveMaterial.SetColor("_EmissionColor", Color.HSVToRGB(_hueSlider.value, _saturationSlider.value, 1.0f) * 2);
    }

    public void RainbowModeToggle()
    {
        _rainbowModeBool = _toggleRainbow.isOn;
    }

    public void ChangeRainbowSpeed()
    {
        _rainbowSpeed = _rainbowSpeedSlider.value;
    }

    private void RainbowMode()
    {
        if (_rainbowHueValue > 1.0f) _rainbowHueValue = 0.0f;
        _rainbowHueValue += 0.01f * _rainbowSpeed;
        _playerEmissiveMaterial.SetColor("_EmissionColor", Color.HSVToRGB(_rainbowHueValue, 1.0f, 1.0f) * 2);
    }
}
