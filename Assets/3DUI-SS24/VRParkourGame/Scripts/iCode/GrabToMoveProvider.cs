using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabToMoveProvider : MonoBehaviour {
    public GameObject gameObjectToMove;
    public GameObject gameObjectGiveGrab1;
    public InputAction moveAction1;
    public GameObject gameObjectTrigger1;
    public GameObject gameObjectGiveGrab2;
    public InputAction moveAction2;
    public GameObject gameObjectTrigger2;
    public GameObject cameraObject;
    public float speedMultiplier = 3.0f;
    private Vector3 prevPosition1;
    private Vector3 prevPosition2;
    public float grabDistance = 2.0f;
    public float forwardJumpSpeed = 5f;

    

    public GameObject handSteeringComponent;
    public float jumpForwardSpeed = 5f;
    public int jumpInterval = 30;
    private int jumpCounter = 0;

    private bool previousGrabMoveActive = false;
    public bool GrabMoveActive = false;
    public bool GrabActive = false;
    private bool previousGrabActive = false;
    void OnEnable() { moveAction1.Enable();moveAction2.Enable(); }
    void OnDisable() { moveAction1.Disable();moveAction2.Disable(); }

    void Update()
    {

        previousGrabActive = GrabActive;
        GrabMoveActive = false;
        GrabActive = false;
        if (moveAction1.WasPressedThisFrame()) {
            prevPosition1 = gameObjectGiveGrab1.transform.localPosition;
        }
        if (moveAction1.IsPressed()) {
            var deltaMovement1 = prevPosition1 - gameObjectGiveGrab1.transform.localPosition;
            Debug.Log("Change:" + deltaMovement1.x + "," + deltaMovement1.y + "," + deltaMovement1.z);
            var RealWorldMove1 = deltaMovement1.x * cameraObject.transform.right + deltaMovement1.y * cameraObject.transform.up
                 + deltaMovement1.z * cameraObject.transform.forward;
            gameObjectToMove.GetComponent<CharacterController>().Move(RealWorldMove1 * speedMultiplier);
            prevPosition1 = gameObjectGiveGrab1.transform.localPosition;
            if (gameObjectTrigger1.GetComponent<TriggerStatus>().TriggerEntered) {
                GrabMoveActive = true;
            }
            GrabActive = true;
        }
        if (moveAction2.WasPressedThisFrame())
        {
            prevPosition2 = gameObjectGiveGrab2.transform.localPosition;
        }
        if (moveAction2.IsPressed())
        {
            var deltaMovement2 = prevPosition2 - gameObjectGiveGrab2.transform.localPosition;
            Debug.Log("Change:" + deltaMovement2.x + "," + deltaMovement2.y + "," + deltaMovement2.z);
            var RealWorldMove2 = deltaMovement2.x * cameraObject.transform.right + deltaMovement2.y * cameraObject.transform.up
                 + deltaMovement2.z * cameraObject.transform.forward;
            gameObjectToMove.GetComponent<CharacterController>().Move(RealWorldMove2 * speedMultiplier);
            prevPosition2 = gameObjectGiveGrab2.transform.localPosition;
            if (gameObjectTrigger2.GetComponent<TriggerStatus>().TriggerEntered)
            {
                GrabMoveActive = true;
            }
            GrabActive = true;
        }
        if (GrabMoveActive) {
            jumpCounter = 0;
        }
        if (moveAction1.WasReleasedThisFrame() || moveAction2.WasReleasedThisFrame()) {
            Physics.Raycast(
               gameObjectToMove.transform.position,
               -gameObjectToMove.transform.up,
               out RaycastHit hit,
               0.5f,
               1 << 0);
            if (previousGrabActive && !GrabActive && jumpCounter == 0 && !handSteeringComponent.GetComponent<HandSteeringProvider>().isFalling)
            {
                jumpCounter = jumpInterval;
            }
        }
        if (jumpCounter > 0) {
            var moveDistance = gameObjectToMove.transform.up * handSteeringComponent.GetComponent<HandSteeringProvider>().gravity * 3 * jumpCounter / jumpInterval * Time.deltaTime;
            moveDistance += gameObjectGiveGrab1.transform.forward * forwardJumpSpeed * Time.deltaTime;
            gameObjectToMove.GetComponent<CharacterController>().Move(moveDistance);
            jumpCounter--;
        }
    }
}
