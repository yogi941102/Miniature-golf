using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole1 : MonoBehaviour {
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
        if (other.gameObject.name == "Ball1")
        {
            Debug.Log("win1");
            canvas.SetActive(true);
            cube.SetActive(false);
            
        }
    }
}
