using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXShotgunControl : MonoBehaviour
{
    [SerializeField] private GameObject _vfx;

    private void Start()
    {
        DisableVFX();
    }

    public void EnableVFX()
    {
        _vfx.SetActive(true);
    }

    public void DisableVFX()
    {
        _vfx.SetActive(false);
    }
}
