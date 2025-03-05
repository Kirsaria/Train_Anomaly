using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHelpButton : MonoBehaviour
{
    public GameObject objectsToToggle; 
    public GameObject helpMenu;
    private bool isMenuVisible = true; 

    public void OnButtonClick()
    {
        isMenuVisible = !isMenuVisible;
        objectsToToggle.SetActive(isMenuVisible);
        helpMenu.SetActive(!isMenuVisible);
    }
}
