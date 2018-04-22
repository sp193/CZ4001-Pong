using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {
    public Text WorldMarkerHelpText;
    public Text Player1MarkerHelpText;
    public Text Player2MarkerHelpText;

    public void OnMarkerFound(ARMarker marker) {
        if (marker.Tag.Equals("WorldMarker")) {
            WorldMarkerHelpText.enabled = false;
        } else if (marker.Tag.Equals("Player1")) {
            Player1MarkerHelpText.enabled = false;
        } else if (marker.Tag.Equals("Player2")) {
            Player2MarkerHelpText.enabled = false;
        } else {
            Debug.Log("Unknown marker found: " + marker.Tag);
        }
    }

    public void OnMarkerLost(ARMarker marker) {
        if (marker.Tag.Equals("WorldMarker")) {
            WorldMarkerHelpText.enabled = true;
        } else if (marker.Tag.Equals("Player1")) {
            Player1MarkerHelpText.enabled = true;
        } else if (marker.Tag.Equals("Player2")) {
            Player2MarkerHelpText.enabled = true;
        } else {
            Debug.Log("Unknown marker lost: " + marker.Tag);
        }
    }
}
