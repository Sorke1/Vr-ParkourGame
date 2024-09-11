using TMPro;
using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class UpdateUITextIWithRaceInfo : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Text component this behavior uses to display a time.")]
        public TextMeshPro textMeshPro;


        public TextMeshPro TextMeshPro
        {
            get => textMeshPro;
            set => textMeshPro = value;
        }

        protected void Awake()
        {
            if (textMeshPro == null)
                Debug.LogWarning("Missing required Text component reference. Use the Inspector window to assign which Text component.", this);
        }

        public void setUIText(RacePerformanceInfo ri)
        {
            Debug.Log("setUIText with Race Info " + ri);
            if (textMeshPro != null)
                textMeshPro.text = ri.ToString();
        }

    }

}