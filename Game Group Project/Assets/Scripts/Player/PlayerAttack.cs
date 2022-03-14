using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Assignables")]
    [SerializeField] private Animator _animator;

    [Header("Attack Collider Assignables")]
    [SerializeField] private GameObject _slamAttackCollider;

    [Header("Misc Assignables")]
    [SerializeField] private Camera _playerCamera;

    private void Awake()
    {
        SlamAttackColliderDeactivate();
    }

    public void PlayerLookToAttack()
    {   
        RaycastHit hit;
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out hit);

        Vector3 lookAtPos = hit.point;
        lookAtPos.y = this.transform.position.y;

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

    public void SlamAttackColliderActivate()
    {
        _slamAttackCollider.SetActive(true);
    }
    
    public void SlamAttackColliderDeactivate()
    {
        _slamAttackCollider.SetActive(false);
    }

    public void StopAnimation()
    {
        _animator.SetBool("basicAttack", false);
        _animator.SetBool("spinAttack", false);
        _animator.SetBool("slamAttack", false);
    }
}
