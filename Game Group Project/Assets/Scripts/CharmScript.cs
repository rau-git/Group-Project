using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmScript : MonoBehaviour
{
    private Collider _myCollider;
    private GameObject _player;

    private void Awake()
    {
        _myCollider = GetComponent<Collider>();
        _player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
