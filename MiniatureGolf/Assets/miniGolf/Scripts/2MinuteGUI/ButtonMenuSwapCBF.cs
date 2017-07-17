using UnityEngine;
using System.Collections;

public class ButtonMenuSwapCBF : MonoBehaviour {

	public string buttonID = "buttonID";
	public GameObject objectToShow = null;
	public void OnEnable()
	{
		BaseGameManager.onButtonPress += onButtonPress;
	}
	public void OnDisable()
	{
		BaseGameManager.onButtonPress -= onButtonPress;
	}
	public void onButtonPress(string str)
	{
		Debug.Log ("onButtonPress" + str);
		if(str.Equals(buttonID))
		{
			MenuStateManager.enterStateUsingGameObject( objectToShow);
		}
	}
}

