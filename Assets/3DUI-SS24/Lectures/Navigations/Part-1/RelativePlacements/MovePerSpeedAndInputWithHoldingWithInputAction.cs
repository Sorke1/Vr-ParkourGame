
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePerSpeedAndInputWithHoldingWithInputAction : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public float speedInKmPerHour = 3.0f;
    public InputAction moveAction;
    void OnEnable() => moveAction.Enable();
    void OnDisable() => moveAction.Disable();
    void Update()
    {
        if (moveAction.IsPressed())
        {
            gameObjectToMove.transform.position
                += gameObjectToMove.transform.right
                * ToMeterPerSeconds(speedInKmPerHour)
                * Time.deltaTime;
        }
    }
    private float ToMeterPerSeconds(float kiloMeterPerHours)
    {
        return kiloMeterPerHours * 1000 / 3600;
    }
}
