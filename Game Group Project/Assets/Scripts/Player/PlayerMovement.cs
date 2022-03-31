using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    [Header("Assignables")] [SerializeField]
    private Camera _playerCamera;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameObject _showPositionPrefab;
    [SerializeField] private LayerMask _walkableLayer;
    [SerializeField] private Animator _animator;
    private NavMeshAgent _agent;

    [Header("Movement Values")] [SerializeField]
    private Vector3 _movePosition;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _showPositionPrefab.SetActive(false);
    }

    private void Start()
    {
        SetCurrentMovePosition(transform.position);
    }

    private void Update() => ShowPositionVisualHandler();

    private void FixedUpdate() => MoveCharacter();

    public void GetInput()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, 100f, _walkableLayer)) return;

        SetCurrentMovePosition(hit.point);

        _animator.SetBool("isMoving", true);
        _showPositionPrefab.SetActive(true);
        _showPositionPrefab.transform.position = GetCurrentMovePosition();
    }

    public void SetCurrentMovePosition(Vector3 moveToHere) => _movePosition = moveToHere;

    private void MoveCharacter() => _agent.SetDestination(GetCurrentMovePosition());

    public void Dodge()
    {
        _agent.enabled = false;
        transform.Translate(-Vector3.forward * _playerStats._dodgeDistance);
        _agent.enabled = true;
        SetCurrentMovePosition(transform.position);
    }

    private Vector3 GetCurrentMovePosition() => _movePosition;

    private void ShowPositionVisualHandler()
    {
        if ((Vector3.Distance(transform.position, _movePosition) > 1.5f)) return;
        
        _showPositionPrefab.SetActive(false);
        _animator.SetBool("isMoving", false);
    }
}

