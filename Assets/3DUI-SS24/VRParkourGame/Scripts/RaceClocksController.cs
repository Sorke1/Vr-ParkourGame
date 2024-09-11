using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceClocksController : MonoBehaviour
    {
        public RacePerformanceInfo performanceInfo;
        [SerializeField] private RaceStopWatch raceStopWatch;
        [SerializeField] private RaceCountDownTimer raceCountDownTimer;
        public void StartRace()
        {
            Debug.Log("Race is starting...");
            raceStopWatch.Begin();
            raceCountDownTimer.Begin(performanceInfo.MaximumTimeToCompleteInSeconds);
        }
        public void StopRace()
        {
            Debug.Log("Race is Finished...");
            raceStopWatch.End();
            raceCountDownTimer.End();
            performanceInfo.SetPlayerTimeToCompleteInSeconds(raceStopWatch.getRaceTimeInSeconds());
        }
    }
}