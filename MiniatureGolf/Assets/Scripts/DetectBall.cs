using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBall : MonoBehaviour {
    public GameObject hole0;
    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;
    public GameObject hole4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball0")
        {
            hole0.SetActive(true);
            hole1.SetActive(false);
            hole2.SetActive(false);
            hole3.SetActive(false);
            hole4.SetActive(false);
        }
        if (other.gameObject.name == "Ball1")
        {
            hole0.SetActive(false);
            hole1.SetActive(true);
            hole2.SetActive(false);
            hole3.SetActive(false);
            hole4.SetActive(false);
        }
        if (other.gameObject.name == "Ball2")
        {
            hole0.SetActive(false);
            hole1.SetActive(false);
            hole2.SetActive(true);
            hole3.SetActive(false);
            hole4.SetActive(false);
        }
        if (other.gameObject.name == "Ball3")
        {
            hole0.SetActive(false);
            hole1.SetActive(false);
            hole2.SetActive(false);
            hole3.SetActive(true);
            hole4.SetActive(false);
        }
        if (other.gameObject.name == "Ball4")
        {
            hole0.SetActive(false);
            hole1.SetActive(false);
            hole2.SetActive(false);
            hole3.SetActive(false);
            hole4.SetActive(true);
        }
    }
}
