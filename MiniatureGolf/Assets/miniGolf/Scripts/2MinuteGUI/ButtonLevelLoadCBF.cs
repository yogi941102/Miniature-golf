using UnityEngine;
using System.Collections;

public class ButtonLevelLoadCBF : MonoBehaviour {

	public string buttonID = "buttonID";
	public int levelToLoad = 1;
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
		if(str.Equals(buttonID))
		{
			Application.LoadLevel( levelToLoad);
		}
	}
}

