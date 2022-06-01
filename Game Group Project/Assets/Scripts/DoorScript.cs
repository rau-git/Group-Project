using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private GameObject _closedDoor;

    [SerializeField] private bool _openStatus;

    private void Start()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        _openDoor.SetActive(true);
        _closedDoor.SetActive(false);
        _openStatus = true;
    }
    
    public void CloseDoor()
    {
        _openDoor.SetActive(false);
        _closedDoor.SetActive(true);
        _openStatus = false;
    }

    public bool CheckOpenStatus()
    {
        return _openStatus;
    }
}
