
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePerSpeedAndInput : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public float speedInKmPerHour = 3.0f;
    void Update()
    {
        //Whether the press started this frame
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
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
