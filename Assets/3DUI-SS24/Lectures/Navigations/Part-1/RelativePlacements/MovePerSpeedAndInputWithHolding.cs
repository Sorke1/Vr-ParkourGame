
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePerSpeedAndInputWithHolding : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public float speedInKmPerHour = 3.0f;
    void Update()
    {
        //Whether the button is currently pressed (aka hold)
        if (Keyboard.current.spaceKey.isPressed)
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
