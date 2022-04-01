using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private GameObject _projectile;

    public bool _attackBool = false;
    private bool _isAttacking = false;

    private void FixedUpdate()
    {
        if (_attackBool && !_isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, transform.position, transform.rotation);
        _isAttacking = false;
    }
}
