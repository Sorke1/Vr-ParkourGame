using Assets._3DUI_SS24.VRParkourGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyMapController : MonoBehaviour
{
    public GameObject playerCameraProvidingGlobalPosition;
    public GameObject playerDistinationOnMap;
    public GameObject TargetDestinationOfTrackOnMap;
    public GameObject SourceDestinationOfTrackOnMap;
    public GameObject MapPlaneInstant;
    public GameObject RaceTracksManager;

    

    // Update is called once per frame
    void Update()
    {
        if (MapPlaneInstant.activeSelf)
        {
            var targetLocation = RaceTracksManager.GetComponent<RaceTrackManager>().endPodium.transform.position;
            var sourceLocation = RaceTracksManager.GetComponent<RaceTrackManager>().startPodium.transform.position;
            var playerLocation = playerCameraProvidingGlobalPosition.transform.position;
            playerDistinationOnMap.transform.localPosition = convertLocation(playerLocation);
            playerDistinationOnMap.transform.localRotation = Quaternion.AngleAxis(playerCameraProvidingGlobalPosition.transform.rotation.eulerAngles.y, new Vector3(0, 1, 0));
            TargetDestinationOfTrackOnMap.transform.localPosition = convertLocation(targetLocation);
            SourceDestinationOfTrackOnMap.transform.localPosition = convertLocation(sourceLocation);
        }
    }

    private Vector3 convertLocation(Vector3 globalLocation) {
        // Normarlize the global position due to a (-30,0,30) bias of the town location, and we will convert it into map position later.
        var result = globalLocation + new Vector3(30, 0, 30);
        result.x = result.x / 300f * 10f - 5f;
        result.y = 0;
        result.z = result.z / 260f * 10f * 0.8f - 4f;
        return result;
    }
}
