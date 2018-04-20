using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
           transform.Translate(0f, 0f, 3f * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0f, 0f, -3f * Time.deltaTime);

	}
}
