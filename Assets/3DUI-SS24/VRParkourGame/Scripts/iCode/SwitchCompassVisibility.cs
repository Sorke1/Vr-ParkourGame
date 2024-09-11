using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCompassVisibility : MonoBehaviour
{
    public InputAction CompassSwitchAction;
    public GameObject compassobj;
    // Update is called once per frame

    void OnEnable()
    {
        CompassSwitchAction.Enable();
    }
    void OnDisable()
    {
        CompassSwitchAction.Disable();
    }

    void Update()
    {
        if (CompassSwitchAction.WasPressedThisFrame())
        {
            compassobj.SetActive(!compassobj.activeSelf);
        }
    }
}
