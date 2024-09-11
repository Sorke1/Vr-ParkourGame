using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RacePodiumMarkerManager : MonoBehaviour
    {
        public string podiumMarkerTag = "RaceTrackPodiumMarker";
        public void HideAll()
        {
            GameObject[] podiumMarkers = GameObject.FindGameObjectsWithTag(podiumMarkerTag);
            foreach (GameObject go in podiumMarkers)
            {
                go.SetActive(false);
            }
        }
    }
}