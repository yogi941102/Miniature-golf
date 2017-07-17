using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public GameObject[] FishPrefab;
    float time = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("hahaha");
        time += Time.deltaTime;
        if (time >=2)
        {
            Debug.Log("hahaha");
            Instantiate(FishPrefab[Random.Range(0, FishPrefab.Length)]);
            time = 0;
        }
	}
}
