using Assets._3DUI_SS24.VRParkourGame;
using UnityEngine;

namespace Assets._3DUI_SS24.Starters.gameplay
{
    public class CompassRotateToTrackEnd : MonoBehaviour
    {
        public GameObject RaceTracksManager;
        void Update()
        {
            if (RaceTracksManager != null)
            {
                this.gameObject.transform.LookAt(RaceTracksManager.GetComponent<RaceTrackManager>().endPodium.transform.position);
            }
        }
    }
}