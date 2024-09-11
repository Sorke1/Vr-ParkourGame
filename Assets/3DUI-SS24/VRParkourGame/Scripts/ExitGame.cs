using UnityEditor;
using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class ExitGame : MonoBehaviour
    {
        public void Exit()
        {
# if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else 
            Application.Quit();
#endif
        }
    }
}