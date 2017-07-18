using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWrongHole : MonoBehaviour {
    public GameObject ball;
    public GameObject[] ballhPrefab;
    public GameObject ballCreator;
    public GameObject camera;
    private int index;
        
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (ball == null)
        {
            index = Random.Range(0, ballhPrefab.Length);
            ball = Instantiate(ballhPrefab[index], ballCreator.transform.position, Quaternion.identity);
            ball.name = "Ball"+index;
            BallScript ballscript = ball.GetComponent<BallScript>();
            ballscript.m_ballMode = BallScript.BallMode.AIM;
            Rigidbody ballrigibody = ball.GetComponent<Rigidbody>();
            ballrigibody.isKinematic = false;
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            AimCamera cameraScript = camera.GetComponent<AimCamera>();
            cameraScript.m_on = true;
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(ball.gameObject,2);
    }
}
