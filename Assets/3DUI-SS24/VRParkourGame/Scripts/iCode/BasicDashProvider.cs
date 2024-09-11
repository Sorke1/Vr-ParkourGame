using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BasicDash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObjectToMove;
    public GameObject gameObjectGivingDashDir;
    public GameObject gameObjectGivePosition;
    public float DashDistance = 10.0f;
    public InputAction moveAction;
    private Vector3 targetPosition;
    public float vibrationAmplitude = 0.5f;
    public float vibrationDuration = 0.5f;
    private bool isPressed = false;

    void OnEnable() { moveAction.Enable(); }
    void OnDisable() { moveAction.Disable(); }

    void Update()
    {
        Vector2 stickinput = moveAction.ReadValue<Vector2>();
        if (stickinput.y > 0.7)
        {
            isPressed = true;
            Physics.Raycast(
               gameObjectGivingDashDir.transform.position,
               gameObjectGivingDashDir.transform.forward,
               out RaycastHit hit,
               DashDistance,
               1 << 0);
            if (hit.collider != null)
            {
                gameObjectGivePosition.transform.position = hit.point;
                targetPosition = hit.point;
            }
        }
        else
        {
            if (isPressed)
            {
                gameObjectToMove.transform.position = targetPosition;
            }
            isPressed = false;
        }
    }
}
