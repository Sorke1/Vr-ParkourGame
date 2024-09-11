using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BasicTeleportProvider : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public GameObject gameObjectGivingJumpDir;
    public GameObject gameObjectGivePosition;
    public GameObject playerCamera4Sound;
    public float JumpDistance = 10.0f;
    public InputAction moveAction;
    private Vector3 targetPosition;
    public float vibrationAmplitude = 0.5f;
    public float vibrationDuration = 0.5f;
    private bool isPressed = false;
    private bool isPositionValid = false;

    void OnEnable() { moveAction.Enable(); }
    void OnDisable() { moveAction.Disable(); }

    private void GenerateSound()
    {
        AudioSource audioSource = playerCamera4Sound.GetComponent<AudioSource>();
        if (audioSource != null)
            audioSource.Play();
        else
            Debug.LogError("No Audio Source Found!");
    }

    private void GenerateVibrations()
    {
        ActionBasedController xrController = gameObjectGivingJumpDir.GetComponent<ActionBasedController>();
        if (xrController != null)
            xrController.SendHapticImpulse(vibrationAmplitude, vibrationDuration);
        else
            Debug.LogError("No XR Controller Found!");
    }

    void Update()
    {
        Vector2 stickinput = moveAction.ReadValue<Vector2>();
        if (stickinput.y > 0.7)
        {
            isPressed = true;
            Physics.Raycast(
               gameObjectGivingJumpDir.transform.position,
               gameObjectGivingJumpDir.transform.forward,
               out RaycastHit hit,
               JumpDistance,
               1 << 0);
            if (hit.collider != null)
            {
                gameObjectGivePosition.transform.position = hit.point;
                targetPosition = hit.point;
                isPositionValid=true;
            }
            else {
                gameObjectGivePosition.transform.position = new Vector3(0,-1,0);
                isPositionValid = false;
            }
        }
        else
        {
            if (isPressed) {
                if (playerCamera4Sound != null) {
                    GenerateSound();
                    GenerateVibrations();
                }
                if (isPositionValid) {
                    gameObjectToMove.transform.position = targetPosition;
                }
            }
            gameObjectGivePosition.transform.position = new Vector3(0, -1, 0);
            isPressed = false;
        }
    }
}