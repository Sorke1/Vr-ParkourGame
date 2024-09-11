
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveVRUserWithReadValue : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public GameObject gameObjectGivingRightDir;
    public float speedInKmPerHour = 3.0f;
    public InputAction moveAction;
    void OnEnable() { moveAction.Enable(); }
    void OnDisable() { moveAction.Disable(); }
    void Update()
    {
        if (moveAction.ReadValue<float>() == 1.0f)
        {
            Debug.Log("moveAction PRESSED " + moveAction.ReadValue<float>());

            gameObjectToMove.transform.position
                += gameObjectGivingRightDir.transform.right
                * ToMeterPerSeconds(speedInKmPerHour)
                * Time.deltaTime;
        }
    }
    private float ToMeterPerSeconds(float kiloMeterPerHours)
    {
        return kiloMeterPerHours * 1000 / 3600;
    }
}
