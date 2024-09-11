using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets._3DUI_SS24.VRParkourGame
{
    [System.Serializable]
    public class ZoneInfo
    {
        public GameObject zoneParent;
        public TeleportationAnchor zoneDefaultStartingPoint;
        public string zoneName;
        public bool shouldBeTheStart;
        public bool shouldHideOtherZoneWhenActive;
    }
}