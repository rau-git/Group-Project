using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Damage : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float _health;

    [Header("Assignables")]
    [SerializeField] private GameObject _uiCanvas;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private GameObject _healingItem;

    private void Awake()
    {
        _uiCanvas.SetActive(false);
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        
        _healthBar.fillAmount = _health / 100;
    }

    public void TakeDamage(float inputDamage)
    {
        if (_health - inputDamage <= 0)
        {
            Die();
        }
        else
        {
            _uiCanvas.SetActive(true);
            _health -= inputDamage;
        }
    }

    public void Die()
    {
        Instantiate(_deathVFX, transform.position - new Vector3(0, 1, 0), transform.rotation);
        Instantiate(_healingItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
