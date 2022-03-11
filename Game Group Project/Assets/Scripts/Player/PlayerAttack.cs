using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Assignables")]
    [SerializeField] private Animation _attackAnimation;
    [SerializeField] private Animation _spinAttackAnimation;
    [SerializeField] private Animation _slamAttackAnimation;
    [SerializeField] private Animation _pentagramAttackAnimation;


    [Header("Misc Assignables")]
    [SerializeField] private Camera _playerCamera;

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
        _attackAnimation.Play();
    }

    public void SpinAttack()
    {
        PlayerLookToAttack();
        _spinAttackAnimation.Play();
    }

    public void SlamAttack()
    {
        PlayerLookToAttack();
        _slamAttackAnimation.Play();
    }

    public void PentagramAttack()
    {
        PlayerLookToAttack();
        _pentagramAttackAnimation.Play();
    }
}
