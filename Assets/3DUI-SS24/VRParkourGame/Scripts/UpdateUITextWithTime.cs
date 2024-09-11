using UnityEngine;
using UnityEngine.UI;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class UpdateUITextWithTime : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Text component this behavior uses to display a time.")]
        Text m_Text;

        float m_time;

        public Text text
        {
            get => m_Text;
            set => m_Text = value;
        }

        protected void Awake()
        {
            if (m_Text == null)
                Debug.LogWarning("Missing required Text component reference. Use the Inspector window to assign which Text component.", this);
        }

        public void setUIText(float time)
        {
            m_time = time;
            if (m_Text != null)
                m_Text.text = m_time.ToString();
        }
        public void setUIText(RacePerformanceInfo ri)
        {
            m_time = ri.RaceTimeCountDownInSeconds;
            if (m_Text != null)
                m_Text.text = m_time.ToString();
        }

    }
}




