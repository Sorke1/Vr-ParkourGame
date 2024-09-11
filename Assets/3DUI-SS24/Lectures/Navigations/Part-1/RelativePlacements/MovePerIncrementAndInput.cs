
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePerIncrementAndInput : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public float moveIncrement = 3.0f;
    void Update()
    {
        //Whether the press started this frame
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            gameObjectToMove.transform.position
                += gameObjectToMove.transform.right
                   * moveIncrement;
        }
    }
}
