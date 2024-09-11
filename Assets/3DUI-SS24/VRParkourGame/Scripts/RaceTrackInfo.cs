using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    [System.Serializable]
    public class RaceTrackInfo
    {
        [Range(0, 10)]
        public int complexity;
        public float MaximumTimeToCompleteInSeconds;
        public string label;
        public Transform startPodiumTransform;
        public Transform endPodiumTransform;
        public Transform resultPodiumTransform;
    }
}