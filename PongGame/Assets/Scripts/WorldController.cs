using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {
    public Text WorldMarkerHelpText;

    public void OnMarkerFound(ARMarker marker)
    {
        Debug.Log("World: marker found");
        WorldMarkerHelpText.enabled = false;
    }

    public void OnMarkerLost(ARMarker marker)
    {
        Debug.Log("World: marker lost");
        WorldMarkerHelpText.enabled = true;
    }
}
