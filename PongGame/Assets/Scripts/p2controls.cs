using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2controls : MonoBehaviour {

    public GameObject marker;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0f, 0f, 3f * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0f, 0f, -3f * Time.deltaTime);

        //Move relative to the marker's Y position.
        if (marker.activeSelf) {
            Vector3 loc = transform.position;
            loc.y = marker.transform.position.y;
            transform.position = loc;
        }
    }
}
