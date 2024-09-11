using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HandSteeringProvider : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public GameObject gameObjectCamera;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject tunnelingProvider;
    public float speedInKmPerHour = 5.0f;
    public float rotationInterval = 30.0f;
    public float speedThreshold = 0.5f;
    public float shakeToRunThreshold = 0.4f;
    public float jumpThreshold = 0.003f;
    public float rotationThreshold = 0.8f;
    public InputAction moveActionRotate;
    public InputAction moveActionStick;
    private bool inputNotProcessed = true;
    private bool isHighSpeedMoving = false;
    public bool isFalling = false;
    public float shakeToRunMultiplier = 4f;
    ITunnelingVignetteProvider tunnelingVignetteProvider;
    public bool limitHeight = true;
    private float rotationDirection = 0f;
    public float gravity = 0.98f;
    public GameObject GrabMoveController;
    public GameObject virtualNose;

    public Toggle toggleTunneling;
    public Toggle toggleVirtualNose;

    public TMP_Text TMPBottomRotate;
    public TMP_Text TMPBottomDirection;

    public bool isContinuousRotating = false;
    public bool isCameraDirection = false;

    public const int rotationCountTotal = 10;
    private int rotationCounter = 0;

    private Vector3 prevLeftControllerPosition;
    private Vector3 prevRightControllerPosition;

    private float prevHeight = 0f;

    private int shakeToRunCounter = 0;

    public int shakeToRunCountTotal = 25;

    public Slider speedSlider;

    void OnEnable() {
        moveActionRotate.Enable();
        moveActionStick.Enable();
    }
    void OnDisable() {
        moveActionRotate.Disable();
        moveActionStick.Disable();
    }
    public void switchRotationMethod(){
        isContinuousRotating = !isContinuousRotating;
        if (isContinuousRotating)
        {
            TMPBottomRotate.text = "Continuous";
        }
        else {
            TMPBottomRotate.text = "Snap";
        }
    }

    void Start() {
        tunnelingVignetteProvider = tunnelingProvider.GetComponent<TunnelingVignetteController>().locomotionVignetteProviders[0];
    }

    public void switchDirectionProvider()
    {
        isCameraDirection = !isCameraDirection;
        if (isCameraDirection)
        {
            TMPBottomDirection.text = "Head";
        }
        else
        {
            TMPBottomDirection.text = "Right Controller";
        }
    }


    void Update()
    {

        Vector3 target = new Vector3();
        Vector2 stickinput = moveActionStick.ReadValue<Vector2>();
        Vector2 rotateinput = moveActionRotate.ReadValue<Vector2>();
        // Normalize the direction horizontally
        Vector3 normForwardVector = rightController.transform.forward;
        Vector3 normRightVector = rightController.transform.right;
        if (isCameraDirection) {
            normForwardVector = gameObjectCamera.transform.forward;
            normRightVector = gameObjectCamera.transform.right;
        }
        if (limitHeight)
        {
            normForwardVector.y = 0;
            normRightVector.y = 0;
            if (!GrabMoveController.GetComponent<GrabToMoveProvider>().GrabMoveActive) {
                target.y -= gravity * Time.deltaTime;
            }
        }
        normForwardVector = normForwardVector.normalized;
        normRightVector = normRightVector.normalized;
        target += stickinput.y * normForwardVector * speedInKmPerHour * Time.deltaTime;
        if (shakeToRunCounter > 0)
        {
            target = target * shakeToRunMultiplier;
            shakeToRunCounter -= 1;
        }
        target += stickinput.x * normRightVector * speedInKmPerHour * Time.deltaTime;
        Debug.Log("CH"+(prevHeight - gameObjectToMove.transform.position.y));
        isHighSpeedMoving = false;
        if (shakeToRunCounter > 0|| stickinput.x < -speedThreshold || stickinput.x > speedThreshold || stickinput.y < -speedThreshold || stickinput.y > speedThreshold)
        {
            if (Mathf.Abs(leftController.transform.localPosition.y - prevLeftControllerPosition.y) > shakeToRunThreshold)
            {
                shakeToRunCounter = shakeToRunCountTotal;
            }
        }
        if ((prevHeight - gameObjectToMove.transform.position.y) > jumpThreshold)
        {
            isHighSpeedMoving = true;
            isFalling = true;
        }
        else {
            isFalling = false;
        }
        if (shakeToRunCounter > 0) {
            isHighSpeedMoving = true;
        }
        if (isHighSpeedMoving && tunnelingVignetteProvider != null)
        {
            tunnelingProvider.GetComponent<TunnelingVignetteController>().BeginTunnelingVignette(tunnelingVignetteProvider);
        }
        
        if (!isHighSpeedMoving && tunnelingVignetteProvider != null)
        {
            tunnelingProvider.GetComponent<TunnelingVignetteController>().EndTunnelingVignette(tunnelingVignetteProvider);
        }
        
        if (!isContinuousRotating)
        {
            if (rotateinput.x > rotationThreshold)
            {
                if (inputNotProcessed)
                {
                    rotationDirection = rotationInterval;
                    rotationCounter = rotationCountTotal;
                }
                inputNotProcessed = false;
            }
            else if (rotateinput.x < -rotationThreshold)
            {
                if (inputNotProcessed)
                {
                    rotationDirection = -rotationInterval;
                    rotationCounter = rotationCountTotal;
                }
                inputNotProcessed = false;
            }
            else
            {
                inputNotProcessed = true;
            }
        }
        else {
            gameObjectToMove.transform.rotation = gameObjectToMove.transform.rotation * Quaternion.AngleAxis(rotationInterval * Time.deltaTime * rotateinput.x*2, gameObjectToMove.transform.up);
        }
        if (rotationCounter > 0) {
            performRotation(gameObjectToMove);
            rotationCounter--;
        }
        prevHeight = gameObjectToMove.transform.position.y;
        gameObjectToMove.GetComponent<CharacterController>().Move(target);
        prevLeftControllerPosition = leftController.transform.localPosition;
        prevRightControllerPosition = rightController.transform.localPosition;
        
    }
    private float ToMeterPerSeconds(float kiloMeterPerHours)
    {
        return kiloMeterPerHours * 1000 / 3600;
    }

    private void performRotation(GameObject gameObjectToMove) {

        gameObjectToMove.transform.rotation = gameObjectToMove.transform.rotation * Quaternion.AngleAxis(rotationDirection/ rotationCountTotal, gameObjectToMove.transform.up);
    }

    public void InformSwitch() {
        if (toggleTunneling.isOn)
        {
            tunnelingVignetteProvider = tunnelingProvider.GetComponent<TunnelingVignetteController>().locomotionVignetteProviders[0];
        }
        else {
            if (isHighSpeedMoving && tunnelingVignetteProvider != null)
            {
                tunnelingProvider.GetComponent<TunnelingVignetteController>().EndTunnelingVignette(tunnelingVignetteProvider);
            }
            isHighSpeedMoving = false;
            tunnelingVignetteProvider = null;
        }
        if (toggleVirtualNose.isOn)
        {
            virtualNose.SetActive(true);
        }
        else {
            virtualNose.SetActive(false);
        }
        
    }

    public void onRotateSpeedChanged() {
        rotationInterval = speedSlider.value;
    }
}