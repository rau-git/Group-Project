using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlameEnemySound : MonoBehaviour
{
    private AudioSource _flameSource;
    [SerializeField] private List<AudioClip> _flameClips;

    private void Awake()
    {
        _flameSource = GetComponent<AudioSource>();
    }

    public void PlayFlameSound()
    {
        RandomBoomEffect();
    }

    private void RandomBoomEffect()
    {
        var index = Random.Range(0, _flameClips.Count);
        _flameSource.clip = _flameClips[index];
        _flameSource.Play();
    }
}
