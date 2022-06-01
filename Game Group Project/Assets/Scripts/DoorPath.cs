using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorPath : MonoBehaviour
{
    [SerializeField] private List<DoorScript> _initial4DoorsList;

    [SerializeField] private DoorScript _backLeftDoor;
    [SerializeField] private DoorScript _backRightDoor;

    [SerializeField] private List<GameObject> _navmeshCutter;

    [SerializeField] private GameObject _navCutterBackFactory;

    [ContextMenu("OpenDoors")]
    public void OpenPath()
    {
        foreach (var door in _initial4DoorsList)
        {
            door.CloseDoor();
            _backLeftDoor.CloseDoor();
            _backRightDoor.CloseDoor();
        }
        
        EnableAllCutters();

        var index = Random.Range(0, _initial4DoorsList.Count);
        
        _initial4DoorsList[index].OpenDoor();
        _navmeshCutter[index].SetActive(false);

        if (_initial4DoorsList[2].CheckOpenStatus())
        {
            if (Random.Range(0, 10) >= 5)
            {
                _backLeftDoor.OpenDoor();
                _navCutterBackFactory.SetActive(false);
            }
        }
        
        if (_initial4DoorsList[3].CheckOpenStatus())
        {
            if (Random.Range(0, 10) >= 5)
            {
                _backRightDoor.OpenDoor();
                _navCutterBackFactory.SetActive(false);
            }
        }
    }

    private void EnableAllCutters()
    {
        foreach (var cutter in _navmeshCutter)
        {
            cutter.SetActive(true);
        }
        
        _navCutterBackFactory.SetActive(true);
    }
}
