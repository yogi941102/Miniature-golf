using UnityEngine;
using System.Collections;

public class AudioToggleButtonCBF : MonoBehaviour {

	public string buttonID = "buttonID";
	public void OnEnable()
	{
		BaseGameManager.onButtonTogglePress += onButtonTogglePress;
	}
	public void OnDisable()
	{
		BaseGameManager.onButtonTogglePress -= onButtonTogglePress;
	}
	public void onButtonTogglePress(string str,bool status)
	{
		if(str.Equals(buttonID))
		{
			Debug.Log("onButtonTogglePress " + str + "  status " + status);
			//simply set the audio volume to either 0 or 1.
			PlayerPrefs.SetFloat("AudioVolume",status?1 : 0);
		}
	}
}
