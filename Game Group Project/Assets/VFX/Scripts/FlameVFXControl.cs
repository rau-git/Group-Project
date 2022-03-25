using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class FlameVFXControl : MonoBehaviour
{
    [SerializeField] private VisualEffect _vfx;
    private void Awake()
    {
        _vfx.playRate = 1f;
        _vfx.Play();
    }
}
