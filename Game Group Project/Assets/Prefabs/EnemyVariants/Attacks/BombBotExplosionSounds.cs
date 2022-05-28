using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombBotExplosionSounds : MonoBehaviour
{
    private AudioSource _explosionSource;
    [SerializeField] private List<AudioClip> _explosionClips;

    private void Awake()
    {
        _explosionSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        RandomBoomEffect();
    }

    private void RandomBoomEffect()
    {
        var index = Random.Range(0, _explosionClips.Count);
        _explosionSource.clip = _explosionClips[index];
        _explosionSource.Play();
    }
}
