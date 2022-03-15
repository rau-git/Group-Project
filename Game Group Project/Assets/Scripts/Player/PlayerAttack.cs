using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Assignables")]
    [SerializeField] private Animator _animator;

    [Header("Attack Collider Assignables")]
    [SerializeField] private GameObject _slamAttackCollider;
    [SerializeField] private GameObject _spinAttackCollider;
    [SerializeField] private GameObject _basicAttackCollider;

    [Header("Misc Assignables")]
    [SerializeField] private Camera _playerCamera;

    private void Awake()
    {
        SlamAttackColliderDeactivate();
        SpinAttackColliderDeactivate();
        BasicAttackColliderDeactivate();
    }

    private void PlayerLookToAttack()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out var hit);

        Vector3 lookAtPos = hit.point;
        lookAtPos.y = transform.position.y;

        transform.LookAt(lookAtPos);
    }

    public void BasicAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("basicAttack", true);
    }

    public void SpinAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("spinAttack", true);
    }

    public void SlamAttack()
    {
        PlayerLookToAttack();
        _animator.SetBool("slamAttack", true);
    }

    private void SlamAttackColliderActivate() => _slamAttackCollider.SetActive(true);

    private void SlamAttackColliderDeactivate() => _slamAttackCollider.SetActive(false);

    private void SpinAttackColliderActivate() => _spinAttackCollider.SetActive(true);

    private void SpinAttackColliderDeactivate() => _spinAttackCollider.SetActive(false);

    private void BasicAttackColliderActivate() => _basicAttackCollider.SetActive(true);

    private void BasicAttackColliderDeactivate() => _basicAttackCollider.SetActive(false);

    public void StopAnimation()
    {
        _animator.SetBool("basicAttack", false);
        _animator.SetBool("spinAttack", false);
        _animator.SetBool("slamAttack", false);
    }
}
