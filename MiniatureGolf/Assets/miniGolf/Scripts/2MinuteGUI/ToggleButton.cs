using UnityEngine;
using System.Collections;

public class ToggleButton : TouchButton 
{

	public GUIText guiText0;

	public string prefix = "Music";

	public string onState = "On";
	public string offState = "Off";
	private bool m_status;
	public string playerPrefData = "";
	public override void Start()
	{
		base.Start ();


		guiText0 = gameObject.GetComponentInChildren<GUIText>();
		updateGUIText();
		updateGUIText();
		BaseGameManager.buttonTogglePress(command,m_status);
	}
	void updateGUIText()
	{
		string postfix = onState;
		if(PlayerPrefs.GetInt(playerPrefData,1)==0)
		{
			postfix = offState;
		}
		if(guiText0)
		{
			guiText0.text = prefix + ":" + postfix;
		}
		int value = PlayerPrefs.GetInt(playerPrefData,1);
		m_status = value==1;
	}
	/// <summary>
	/// Toggles the player preference.
	/// </summary>
	public void togglePlayerPref()
	{
		int value = PlayerPrefs.GetInt(playerPrefData,1);
		if(value==0)
		{
			value = 1;
		}else{
			value = 0;
		}
		PlayerPrefs.SetInt(playerPrefData,value);
		m_status = value==1;
	}
	public override void onPress()
	{
		togglePlayerPref();
		updateGUIText();
		BaseGameManager.buttonTogglePress(command,m_status);
	}
}
