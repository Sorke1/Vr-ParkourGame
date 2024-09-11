using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RacePerformanceInfo : MonoBehaviour
    {
        public float MaximumTimeToCompleteInSeconds;
        public float PlayerTimeToCompleteInSeconds;
        public float PlayerDistanceToTarget;
        public bool HasSuccessfullyCompletedTheRace;
        public float RaceTimeCountDownInSeconds;

        public void SetHasSuccessfullyCompletedTheRace(bool b) { HasSuccessfullyCompletedTheRace = b; }
        public void SetPlayerTimeToCompleteInSeconds(float time) { PlayerTimeToCompleteInSeconds = time; }
        public void SetMaximumTimeToCompleteInSeconds(float time) { MaximumTimeToCompleteInSeconds = time; }

        public override string ToString()
        {
            return $"" + (HasSuccessfullyCompletedTheRace ? "You Won!" : "You Lost")
                + "\n" + $"Max Race Time {MaximumTimeToCompleteInSeconds}"
                + "\n" + $" Your Time {PlayerTimeToCompleteInSeconds}";
        }
    }
}