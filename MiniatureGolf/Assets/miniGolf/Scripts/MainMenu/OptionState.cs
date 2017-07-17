using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// The Option menu state.
/// </summary>
public class OptionState : BaseMenuState 
{
	#region variables
	/// <summary>
	/// A ref to the background texture
	/// </summary>
	public Texture backTexture;
	/// <summary>
	/// The text for the options box
	/// </summary>
	public string optionSTR = "Options";
	/// <summary>
	/// The text for the graphics button
	/// </summary>
	public string graphicsSTR = "Graphics";
	/// <summary>
	/// The text for the audio button
	/// </summary>	
	public string audioSTR = "Audio";
	/// <summary>
	/// The text for the input button
	/// </summary>	
	public string inputSTR = "Input";
	
	/// <summary>
	/// The text for the main menu string
	/// </summary>
	public string menuMenuSTR = "Main Menu";
	/// <summary>
	/// A ref to the graphics GameObject
	/// </summary>
	public GameObject graphicsGO;
	
	/// <summary>
	/// A ref to the audio GameObject
	/// </summary>'
	public GameObject audioGO;
	
	/// <summary>
	/// A ref to the input GameObject
	/// </summary>
	public GameObject inputGO;
	
	/// <summary>
	/// A ref to the main menu GameObject
	/// </summary>
	public GameObject mainMenuGO;
		
	
	//our private currently selected gameObject
	private GameObject m_currentSelectedGO;
	
	#endregion

	void swapGameObject(GameObject go)
	{
		
		if(m_currentSelectedGO && m_currentSelectedGO!=go)
		{
			m_currentSelectedGO.SendMessage("disable",-1);
		}
		if(go)
		{
			go.SendMessage("enable");
		}
		m_currentSelectedGO = go;		
		
	}
	public override void onGUI()
	{
		float offsetX = transform.position.x + MenuConstants.OFFSET_X;
		float offsetY = transform.position.y + MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;
		
		//draw out background texture
		if(backTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect (0,0,1f,1f),backTexture);
		}	
		
	
		//draw out box		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), optionSTR);
		
		//draw the graphics button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.2f,.35f,.1f), graphicsSTR))
		{
			swapGameObject(graphicsGO);
		}
		
		//draw the audio button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.325f,.35f,.1f), audioSTR))
		{
			swapGameObject(audioGO);
		}		
		
		//draw the input button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.45f,.35f,.1f), inputSTR))
		{
			swapGameObject(inputGO);
		}		
		
		
		//draw the main menu button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f), menuMenuSTR))
		{
			if(m_currentSelectedGO)
			{
				m_currentSelectedGO.SendMessage("disable",-1);
			}
			swapObjects(mainMenuGO);
		}
	}
}
