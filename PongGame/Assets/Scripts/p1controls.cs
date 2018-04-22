using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1controls : MonoBehaviour {

    public GameObject marker;
    private Vector3 startLoc;

	// Use this for initialization
	void Start () {
        startLoc = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        //Move relative to the marker's Y-position.
        if (marker.activeSelf) {
            Vector3 loc = transform.localPosition;
            transform.localPosition = new Vector3(startLoc.x, startLoc.z, marker.transform.localPosition.z);
        }
    }
}
