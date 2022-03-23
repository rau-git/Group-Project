using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static bool _pauseBool;

    [Header("Scripts to Pause")]
    [SerializeField] private PlayerInput _playerInputScript;
    
    [Header("Assignables")]
    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        _pauseBool = false;
        _pauseMenu.SetActive(_pauseBool);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPauseBool();
            _pauseMenu.SetActive(_pauseBool);
        }
    }

    [ContextMenu("Pause")]
    public void SwitchPauseBool()
    {
        _pauseBool = !_pauseBool;
        PauseGame();
    }

    private void PauseGame()
    {
        AudioListener.pause = _pauseBool;
        
        if (_pauseBool)
        {
            Time.timeScale = 0;
            _playerInputScript.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            _playerInputScript.enabled = true;
        }
    }
}
