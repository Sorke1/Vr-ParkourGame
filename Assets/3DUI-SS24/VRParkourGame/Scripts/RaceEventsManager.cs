using UnityEngine;
using UnityEngine.Events;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceEventsManager : MonoBehaviour
    {
        public UnityEvent<RacePerformanceInfo> OnRaceStarted;
        public void TriggerOnRaceStartedEvent(RacePerformanceInfo ri) { OnRaceStarted?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceEnded;
        public void TriggerOnRacedEndedEvent(RacePerformanceInfo ri) { OnRaceEnded?.Invoke(ri); }


        public UnityEvent<RacePerformanceInfo> OnRaceRestartRequired;
        public void TriggerOnRaceRestartRequiredEvent(RacePerformanceInfo ri) { OnRaceRestartRequired?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceNextRequired;
        public void TriggerOnRaceNextRequiredEvent(RacePerformanceInfo ri) { OnRaceNextRequired?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceExitRequired;
        public void TriggerOnRaceExitRequiredEvent(RacePerformanceInfo ri) { OnRaceExitRequired?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceTimeUpdated;
        public void TriggerOnRaceTimeUpdatedEvent(RacePerformanceInfo ri)
        {
            OnRaceTimeUpdated?.Invoke(ri);

        }
        public UnityEvent<RacePerformanceInfo> OnRaceTimeCountDownExpired;
        public void TriggerOnRaceTimeCountDownExpiredEvent(RacePerformanceInfo ri) { OnRaceTimeCountDownExpired?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceSceneLoaded;
        public void TriggerOnSceneLoadedEvent(RacePerformanceInfo ri) { OnRaceSceneLoaded?.Invoke(ri); }

        public UnityEvent<RacePerformanceInfo> OnRaceSceneUnLoaded;
        public void TriggerOnSceneUnLoadedEvent(RacePerformanceInfo ri) { OnRaceSceneUnLoaded?.Invoke(ri); }

    }
}