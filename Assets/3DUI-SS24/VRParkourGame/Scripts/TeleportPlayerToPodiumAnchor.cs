using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class TeleportPlayerToPodiumAnchor : MonoBehaviour
    {
        public TeleportationAnchor teleportationAnchor;
        public TeleportationProvider teleportationProvider;

        public void TeleportToAnchor()
        {
            TeleportRequest teleportRequest = new TeleportRequest();
            teleportRequest.destinationPosition = teleportationAnchor.transform.position;
            teleportRequest.destinationRotation = teleportationAnchor.transform.rotation;
            teleportRequest.matchOrientation = teleportationAnchor.matchOrientation;
            teleportationProvider.QueueTeleportRequest(teleportRequest);
            Debug.Log("Teleportation Request :" + teleportRequest);
        }
    }
}