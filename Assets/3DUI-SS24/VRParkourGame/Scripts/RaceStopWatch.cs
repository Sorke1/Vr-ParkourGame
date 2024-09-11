using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceStopWatch : MonoBehaviour
    {
        [SerializeField] private float timeSinceStarted, timeWhenStopped;
        private bool bStartedWatch = false;
        private bool bStoppedWatch = false;
        public void Begin()
        {
            timeSinceStarted = Time.realtimeSinceStartup;
            bStartedWatch = true;
        }

        public void End()
        {
            timeWhenStopped = Time.realtimeSinceStartup;
            bStartedWatch = false;
            bStoppedWatch = true;
        }

        public float getElaspedTimeinSeconds()
        {
            return bStoppedWatch ? timeWhenStopped : bStartedWatch ? Mathf.Max(Time.realtimeSinceStartup - timeSinceStarted, 0.0f) : 0.0f;
        }

        public float getRaceTimeInSeconds()
        {
            return Mathf.Max(timeWhenStopped - timeSinceStarted, 0.0f);
        }
    }
}