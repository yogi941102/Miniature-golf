using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole4 : MonoBehaviour {
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
        if (other.gameObject.name == "Ball4")
        {
            Debug.Log("win4");
            canvas.SetActive(true);
            cube.SetActive(false);
        }
    }
}
