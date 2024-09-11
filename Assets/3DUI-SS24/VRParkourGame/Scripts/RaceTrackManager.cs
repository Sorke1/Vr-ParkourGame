using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceTrackManager : MonoBehaviour
    {
        public RacePerformanceInfo racePerformanceInfo;
        public RaceTracks tracks;
        public GameObject startPodium;
        public GameObject endPodium;
        public GameObject resultsPodium;
        public int startingTrack;

        private int currentTrackIdx = 0;
        private int numberofTracks;
        private RaceTrackInfo currentTrack;

        private void Awake()
        {
            numberofTracks = tracks.raceParkourTracks.Count;
            if (numberofTracks == 0) throw new Exception("No Tracks Defined in Race Track Info");
            if (startingTrack < 0 || startingTrack >= numberofTracks) throw new Exception("Starting tracks number is invalid");
            currentTrackIdx = startingTrack;
        }
        public void PlacePodiumsForNextTrack()
        {
            FetchNewRaceTrackInfo();
            UpdateCurrentRacePerfomanceInfo();
            AssignWorldTransform(startPodium, currentTrack.startPodiumTransform);
            AssignWorldTransform(endPodium, currentTrack.endPodiumTransform);
            AssignWorldTransform(resultsPodium, currentTrack.resultPodiumTransform);
        }
        private void FetchNewRaceTrackInfo()
        {
            currentTrack = tracks.raceParkourTracks[currentTrackIdx];
            currentTrackIdx = (currentTrackIdx + 1 >= numberofTracks) ? currentTrackIdx = startingTrack : currentTrackIdx + 1;
        }
        private void AssignWorldTransform(GameObject go, Transform transform)
        {
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.transform.localScale = transform.localScale;
        }

        private void UpdateCurrentRacePerfomanceInfo()
        {
            racePerformanceInfo.SetMaximumTimeToCompleteInSeconds(currentTrack.MaximumTimeToCompleteInSeconds);
        }
        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame) PlacePodiumsForNextTrack(); // for quick testing
        }
    }
}