using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceCheatAction : MonoBehaviour
    {
        public string cheatDescription = "Here - descripted the cheat action";
        public InputAction cheatInputAction;
        public UnityEvent<InputAction.CallbackContext> OnCheatInputActionPerformed;
        private void Awake()
        {
            cheatInputAction.performed += cheatCallBack;
        }
        private void cheatCallBack(InputAction.CallbackContext context)
        {
            OnCheatInputActionPerformed?.Invoke(context);
        }
        private void OnEnable()
        {
            cheatInputAction.Enable();
        }
        private void OnDisable()
        {
            cheatInputAction.Disable();
        }
    }
}