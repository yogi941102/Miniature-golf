using UnityEngine;
using System.Collections;

public class SetPracticeMode : MonoBehaviour {
	public bool practiceMode = false;
	// Use this for initialization
	void Start () {
		Constants.setCourseIndex(0);
		Constants.setPracticeMode(practiceMode);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
