using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyHeadDirectedSteering : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public GameObject gameObjectGivingRightDir;
    public float speedInKmPerHour = 3.0f;
    public InputAction moveAction;

    void OnEnable() { moveAction.Enable(); }
    void OnDisable() { moveAction.Disable(); }
    void Update()
    {
        Vector3 dir = moveAction.ReadValue<Vector3>(); // doc https://docs.unity3d.com/Packages/com.unity.inputsystem@1.8/manual/ActionBindings.html#3d-vector
        Debug.Log("dir:" + dir);
        gameObjectToMove.transform.position
        += (gameObjectGivingRightDir.transform.up * dir.y
        + gameObjectGivingRightDir.transform.right * dir.x
        + gameObjectGivingRightDir.transform.forward * dir.z)
        * ToMeterPerSeconds(speedInKmPerHour)
        * Time.deltaTime;
    }
    private float ToMeterPerSeconds(float kiloMeterPerHours)
    {
        return kiloMeterPerHours * 1000 / 3600;
    }

}
