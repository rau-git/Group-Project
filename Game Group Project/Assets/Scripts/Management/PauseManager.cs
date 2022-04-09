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
    [SerializeField] private GameObject _playerHUD;
    [SerializeField] private GameObject _skillMenu;
    private InputControls _inputControls;

    private void Awake()
    {
        _pauseBool = false;
        _pauseMenu.SetActive(_pauseBool);
        
        _inputControls = new InputControls();
        _inputControls.Enable();
    }

    private void Update()
    {
        if (_inputControls.Player.PauseMenu.triggered)
        {
            SwitchPauseBool();
            _pauseMenu.SetActive(_pauseBool);
        }
        if (_inputControls.Player.SkillMenu.triggered)
        {
            ToggleSkillMenu();
        }
    }
    
    public void ToggleSkillMenu()
    {
        SwitchPauseBool();
        _skillMenu.SetActive(!_skillMenu.activeInHierarchy);
    }
    
    public void SwitchPauseBool()
    {
        _pauseBool = !_pauseBool;
        _playerHUD.SetActive(!_pauseBool);
        PauseGame();
    }

    public void ResumeGame()
    {
        SwitchPauseBool();
        _pauseMenu.SetActive(_pauseBool);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
