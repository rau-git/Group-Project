using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _showPositionPrefab;
    [SerializeField] private LayerMask _walkableLayer;
    private NavMeshAgent _agent;

    [Header("Movement Values")]
    [SerializeField] private Vector3 _movePosition;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _showPositionPrefab.SetActive(false);
    }

    private void Update()
    {
        ShowPositionVisualHandler();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    public void GetInput()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, _walkableLayer))
        {
            SetCurrentMovePosition(hit.point);

            _showPositionPrefab.SetActive(true);
            _showPositionPrefab.transform.position = GetCurrentMovePosition();
        }  
    }

    public void MoveCharacter() => _agent.SetDestination(GetCurrentMovePosition());

    public void SetCurrentMovePosition(Vector3 moveToHere) => _movePosition = moveToHere;

    public Vector3 GetCurrentMovePosition() => _movePosition;

    private void ShowPositionVisualHandler()
    {
        if (Vector3.Distance(transform.position, _movePosition) < 1.5f)
        {
            _showPositionPrefab.SetActive(false);
        }
    }
}

