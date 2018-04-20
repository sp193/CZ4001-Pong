using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour {
    public Text p1s;
    public Text p2s;
    private Vector3 reflectNormal;
    private int p1score;
    private int p2score;
    private bool start = false;
    private bool score = false; //false = p1, true =p2
    private bool reflect = false; 
    public GameObject p1;
    public GameObject p2;
    // Use this for initialization
    void Start () {
        p1score = 0;
        p2score = 0;
        transform.position = new Vector3(p1.transform.position.x+0.6f, p1.transform.position.y+0.5f, p1.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if(!start)
            if(!score)
                transform.position = new Vector3(p1.transform.position.x+0.5f, p1.transform.position.y +0.5f, p1.transform.position.z);
            else
                transform.position = new Vector3(p2.transform.position.x - 0.5f, p2.transform.position.y + 0.5f, p2.transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if (!reflect) 
            checkStart();
        else
            checkReflect(reflectNormal);
        p1s.text = "Player 1: " + p1score;
        p2s.text = "Player 2: " + p2score;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("p1 goal"))
        {
            p2score++;
            start = false;
            score = false;
            reflect = false;
            reflectNormal = new Vector3();
        }
        if (collision.gameObject.name.Equals("p2 goal")) {
            p1score++;
            start = false;
            score = true;
            reflect = false;
            reflectNormal = new Vector3();
        }
        if (collision.gameObject.name.Equals("p1Left") || collision.gameObject.name.Equals("p1Right") || collision.gameObject.name.Equals("p2Left") || collision.gameObject.name.Equals("p2Right")) {
            reflect = true;
            reflectNormal = calNormal(collision);
        }
        print(collision.gameObject.name);
    }
    Vector3 calNormal(Collision collision) {
        Vector3 normal = collision.contacts[0].normal;
        if (collision.contacts.Length > 1)
        {
            for (int i = 1; i < collision.contacts.Length; i++)
            {
                normal += collision.contacts[i].normal;
            }
            normal /= collision.contacts.Length;
        }
        return normal.normalized;
    }
    void checkStart() {
        if (start)
            if (!score)
                transform.Translate(2f*Time.deltaTime, 0f, 0f);
            else
                transform.Translate(-2f*Time.deltaTime, 0f, 0f);
    }
    void checkReflect(Vector3 normal) {
        if (reflect)
        {
            transform.Translate(normal.x/15, 0f, normal.z/15);
        }
    }
}
