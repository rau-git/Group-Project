using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CullDeathVFX : MonoBehaviour
{
    [SerializeField] private VisualEffect _deathVFX;
    private void Awake()
    {
        _deathVFX.Play();
        Destroy(gameObject, 5f);
    }
}
