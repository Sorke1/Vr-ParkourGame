using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class ZoneController : MonoBehaviour
    {
        public List<ZoneInfo> zones = new List<ZoneInfo>();
        public TeleportationProvider teleportationProvider;
        private ZoneInfo zoneSelectedAsStartUp;

        // private void Start()
        // {
        //     TeleportPlayerToStarUpZone();
        // }

        public void TeleportPlayerToStarUpZone()
        {
            GetStartUpZone();
            TeleportToSelectedZone();
            HideOtherZoneOrNot();
        }
        private void GetStartUpZone()
        {
            var result = zones.Where(x => x.shouldBeTheStart == true).ToList();
            if (result.Count == 0) throw new System.Exception("No Zone Defined as Startup");
            zoneSelectedAsStartUp = result[0];
        }
        private void TeleportToSelectedZone()
        {
            TeleportRequest teleportRequest = new TeleportRequest();
            teleportRequest.destinationPosition = zoneSelectedAsStartUp.zoneDefaultStartingPoint.transform.position;
            teleportRequest.destinationRotation = zoneSelectedAsStartUp.zoneDefaultStartingPoint.transform.rotation;
            teleportRequest.matchOrientation = zoneSelectedAsStartUp.zoneDefaultStartingPoint.matchOrientation;
            teleportationProvider.QueueTeleportRequest(teleportRequest);
        }
        private void HideOtherZoneOrNot()
        {
            if (zoneSelectedAsStartUp.shouldHideOtherZoneWhenActive)
            {
                foreach (var z in zones)
                {
                    if (z != zoneSelectedAsStartUp) z.zoneParent.SetActive(false);
                }
            }
        }
    }
}