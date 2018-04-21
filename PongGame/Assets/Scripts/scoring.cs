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
    public Text GameOverText;
    public float speed;
    public float reflectionFactor;
    // Use this for initialization
    void Start () {
        p1score = 0;
        p2score = 0;
        GameOverText.enabled = true;
    }
	
    private void GameOver()
    {
        start = false;
        score = false;
        GameOverText.enabled = true;
        reflect = false;
        reflectNormal = new Vector3();
    }

	// Update is called once per frame
	void Update () {
        if(!start)
            if(!score)
                transform.position = new Vector3(p1.transform.position.x+0.25f, p1.transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(p2.transform.position.x-0.25f, p2.transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameOverText.enabled = false;
            start = true;
        }
        if((transform.position.x > 4 || transform.position.x < -4)
            || (transform.position.y > 4 || transform.position.x < -4))
        {
            GameOver();
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
            GameOver();
        }
        else if (collision.gameObject.name.Equals("p2 goal")) {
            p1score++;
            GameOver();
        }
        if (collision.gameObject.name.Equals("p1Left") || collision.gameObject.name.Equals("p1Right") || collision.gameObject.name.Equals("p2Left") || collision.gameObject.name.Equals("p2Right") || collision.gameObject.CompareTag("Wall")) {
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
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            else
                transform.Translate((-speed) * Time.deltaTime, 0f, 0f);
    }
    void checkReflect(Vector3 normal) {
        if (reflect)
        {
            transform.Translate(normal.x / reflectionFactor, 0f, normal.z / reflectionFactor);
        }
    }
}
