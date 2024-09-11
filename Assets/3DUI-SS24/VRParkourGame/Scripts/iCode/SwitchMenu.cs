using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchMenu : MonoBehaviour
{
    public InputAction switchMenuDisplay;
    public InputAction switchMapDisplay;

    // Menu itself and submenu Visibility Control
    public GameObject menuObj;
    public GameObject leftMenuObj;
    public GameObject rightMenuObj;

    public GameObject mapObj;
    public GameObject compassObj;

    public TMP_Text TMPBottomNav;
    private bool usingMap = true;

    public int hideMenuInterval = 60;
    private int hideMenuCounter = 0;
    // Update is called once per frame

    void OnEnable()
    {
        switchMenuDisplay.Enable();
        switchMapDisplay.Enable();
    }
    void OnDisable()
    {
        switchMenuDisplay.Disable();
        switchMapDisplay.Disable();
    }

    void Update()
    {
        if (switchMenuDisplay.WasPressedThisFrame())
        {
            menuObj.SetActive(!menuObj.activeSelf);
            if (menuObj.activeSelf) {
                hideMenuCounter = -1;
            }
        }
        if (switchMapDisplay.WasPressedThisFrame()) {
            if (usingMap)
            {
                mapObj.SetActive(!mapObj.activeSelf);
            }
            else
            {
                compassObj.SetActive(!compassObj.activeSelf);
            }
            if (menuObj.activeSelf) {
                hideMenuCounter = hideMenuInterval;
            }
        }
        if (hideMenuCounter < 0 || !menuObj.activeSelf) {
            // DO Nothing
            hideMenuCounter = -1;
        }
        else if (hideMenuCounter > 0 && menuObj.activeSelf)
        {
            hideMenuCounter--;
        }
        else {
            menuObj.SetActive(false);
            hideMenuCounter = -1;
        }
    }

    public void switchNavMethod() {
        usingMap = !usingMap;
        if (usingMap)
        {
            TMPBottomNav.text = "Map";
        }
        else {
            TMPBottomNav.text = "Compass";
        }
        mapObj.SetActive(false);
        compassObj.SetActive(false);
    }

    public void switchEffectsMethod() { 
        
    }

}
