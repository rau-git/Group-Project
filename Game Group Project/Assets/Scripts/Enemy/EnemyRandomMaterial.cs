using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRandomMaterial : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private void Start()
    {
        Material selectedMaterial = _materials[Random.Range(0, _materials.Length)];
        
        gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
        gameObject.GetComponent<MeshRenderer>().material.color *= Random.ColorHSV(0f, 1f, 0.3f, 0.3f, 0.8f, 0.8f);
    }
}
