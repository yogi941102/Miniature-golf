using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWrongHole : MonoBehaviour {
    public GameObject ball;
    public GameObject[] ballhPrefab;
    public GameObject ballCreator;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position1 = new Vector3(-0.58f, 5.61f, 27.37f);
        if (ball == null)
        {
            ball = Instantiate(ballhPrefab[Random.Range(0, ballhPrefab.Length)], ballCreator.transform.position, Quaternion.identity);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(ball.gameObject,2);
    }
}
