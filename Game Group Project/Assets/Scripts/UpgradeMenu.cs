using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private void Awake()
    {
        CloseUpgradeMenu();
    }

    public void CloseUpgradeMenu()
    {
        gameObject.SetActive(false);
    }
}
