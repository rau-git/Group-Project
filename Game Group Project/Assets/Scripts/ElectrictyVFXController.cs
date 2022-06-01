using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ElectrictyVFXController : MonoBehaviour
{
    [SerializeField] private VisualEffect _electricityVFX;
    [SerializeField] private string _electricityVFXColorName;
    public Material _playerMaterial;
    private Color _currentPlayerColor;

    private void OnEnable()
    {
        _currentPlayerColor = _playerMaterial.GetColor("_EmissionColor");
        _electricityVFX.SetVector4(_electricityVFXColorName, new Vector4(_currentPlayerColor.r, _currentPlayerColor.g, _currentPlayerColor.b, 1.0f));
    }
}
