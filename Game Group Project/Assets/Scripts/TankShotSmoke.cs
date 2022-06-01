using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotSmoke : MonoBehaviour
{
    [SerializeField] private GameObject _rightVFX;
    [SerializeField] private GameObject _leftVFX;
    [SerializeField] private AudioSource _tankShotSound;

    [SerializeField] private List<AudioClip> _tankShotClips;
    
    private void Awake()
    {
        _tankShotSound = GetComponent<AudioSource>();
        DisableBothVFX();
    }

    private void ActivateRightVFX()
    {
        _rightVFX.SetActive(true);
        GetRandomClip();
    }
    
    private void ActivateLeftVFX()
    {
        _leftVFX.SetActive(true);
        GetRandomClip();
    }

    private void GetRandomClip()
    {
        var index = Random.Range(0, _tankShotClips.Count);
        _tankShotSound.clip = _tankShotClips[index];
        _tankShotSound.Play();
    }

    private void DisableBothVFX()
    {
        _rightVFX.SetActive(false);
        _leftVFX.SetActive(false);
    }
}
