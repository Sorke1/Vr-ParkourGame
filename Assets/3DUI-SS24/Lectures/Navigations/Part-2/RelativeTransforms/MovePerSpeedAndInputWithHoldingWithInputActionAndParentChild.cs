
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePerSpeedAndInputWithHoldingWithInputActionAndParentChild : MonoBehaviour
{
    public GameObject gameObjectToMove;

    public GameObject gameObjectChildOfObjectToMove;
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

            Debug.Log("----- New Update------------");
            Debug.Log("Parent's transform.position " + transform.position, gameObjectToMove);
            Debug.Log("Parent's transform.localPosition " + transform.localPosition, gameObjectToMove);
            Debug.Log("Child's transform.position " + gameObjectChildOfObjectToMove.transform.position, gameObjectChildOfObjectToMove);
            Debug.Log("Child's transform.localPosition " + gameObjectChildOfObjectToMove.transform.localPosition, gameObjectChildOfObjectToMove);
            Debug.Log("-----------------------------");
        }
    }
    private float ToMeterPerSeconds(float kiloMeterPerHours)
    {
        return kiloMeterPerHours * 1000 / 3600;
    }
}
