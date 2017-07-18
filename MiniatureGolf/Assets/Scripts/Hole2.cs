using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole2 : MonoBehaviour {
    public GameObject canvas;
    public GameObject cube;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball2")
        {
            Debug.Log("win2");
            canvas.SetActive(true);
            cube.SetActive(false);
        }
    }
}
