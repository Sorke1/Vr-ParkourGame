using UnityEngine;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class TeleportToTarget : MonoBehaviour
    {
        public Transform destination;
        public GameObject objectToTeleport;
        public void Teleport()
        {
            objectToTeleport.transform.position = destination.position;
        }
    }
}