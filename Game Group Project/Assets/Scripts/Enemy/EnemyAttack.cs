using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyAttack : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private VisualEffect _flameVFX;
    [SerializeField] private GameObject _flameAttackCollider;
    [SerializeField] private GameObject _explosion;

    public bool _attackBool = false;
    private bool _isAttacking = false;

    private enum AttackTypes { ProjectileAttack, FlameAttack };
    [SerializeField] private AttackTypes attacks;

    private void Start()
    {
        if (_flameVFX == null || _flameAttackCollider == null) return;
        _flameVFX.Stop();
        _flameAttackCollider.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_attackBool && !_isAttacking)
        {
            switch (attacks)
            {
                case AttackTypes.ProjectileAttack:
                    StartCoroutine(ProjectileAttack());
                    break;
                case AttackTypes.FlameAttack:
                    StartCoroutine(FlameAttack());
                    break;
            }
        }
    }

    private IEnumerator ProjectileAttack()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, transform.position, transform.rotation);
        _isAttacking = false;
    }

    private IEnumerator FlameAttack()
    {
        _isAttacking = true;
        _flameVFX.Play();
        _flameAttackCollider.SetActive(true);
        yield return new WaitForSeconds(1f);
        _flameVFX.Stop();
        _flameAttackCollider.SetActive(false);
        yield return new WaitForSeconds(3f);
        _isAttacking = false;
    }

    public void BoomAttack()
    {
        Instantiate(_explosion, transform.position, transform.rotation);
    }
}
