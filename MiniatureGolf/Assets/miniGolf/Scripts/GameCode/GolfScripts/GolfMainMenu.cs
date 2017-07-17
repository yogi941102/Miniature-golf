//#define GOT_PRIME31_GAMECENTER

using UnityEngine;
using System.Collections;
/// <summary>
/// Main menu state
/// </summary>
public class GolfMainMenu: BaseMenuState 
{
	#region variables
	
	/// <summary>
	/// The back texture.
	/// </summary>
	public Texture backTexture;
	
	/// <summary>
	/// A ref to the options gameObject
	/// </summary>
	public GameObject optionsGO;
	
	
	/// <summary>
	/// A ref to the credits gameObject
	/// </summary>
	public GameObject creditsGO;
	
	/// <summary>
	/// A ref to the level select gameObject
	/// </summary>
	public GameObject levelSelectGO;

	/// <summary>
	/// Do we want to use the quit button
	/// </summary>	
	public bool useQuitButton = false;
	
	/// <summary>
	/// Do we want to use the highscore button
	/// </summary>	
	public bool useHighscoreButton = false;
	
	
	
	/// <summary>
	/// The main menu box's text
	/// </summary>		
	public string menuMenuSTR = "Main Menu";
	
	
	/// <summary>
	/// The start button text
	/// </summary>			
	public string startButtonSTR = "Regular";
	
	/// <summary>
	/// The option button text
	/// </summary>	
	public string optionsSTR = "Options";
	
	/// <summary>
	/// The credits button text
	/// </summary>		
	public string creditsSTR = "Credits";
	
	/// <summary>
	/// The quit button text
	/// </summary>		
	public string quitSTR = "Quit";
	
	/// <summary>
	/// The highscore button text
	/// </summary>		
	public string highscoreSTR = "Highscore";
	
	public string practiceModeSTR = "Practice";
	/// <summary>
	/// The intro text gui stryle
	/// </summary>			
	public GUIStyle introTextGS;
	
#endregion
	
	void Start()
	{
		//lets show the cursor and unlock it (incase it was).
		Screen.lockCursor=false;
		Cursor.visible=true;
		Time.timeScale=1;
		if(RuntimePlatform.IPhonePlayer==Application.platform)
		{
#if GOT_PRIME31_GAMECENTER
			if(GameCenterBinding.isGameCenterAvailable())
			{
				GameCenterBinding.authenticateLocalPlayer();
			}
#endif
		}
		m_on=true;
	}
	//deactivate this object and active the incoming one.
	void changeGameObject(GameObject go)
	{
		go.SetActive(true);
		gameObject.SetActive(false);
	}

	public override void onGUI()
	{
		float offsetX = transform.position.x+MenuConstants.OFFSET_X;
		float offsetY = transform.position.y+MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;
	
		//draw out background texture
		if(backTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect (0,0,1f,1f),backTexture);
		}	
		
		//draw the menu box
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), menuMenuSTR);

		//draw the button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.25f,.35f,.1f), startButtonSTR))
		{
			Constants.setPracticeMode(false);
			
			swapObjects(levelSelectGO);
		}

		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.375f,.35f,.1f), practiceModeSTR))
		{
			Constants.setPracticeMode(true);
			
			swapObjects(levelSelectGO);
		}
		
		//draw the option button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.5f,.35f,.1f), optionsSTR))
		{
			swapObjects(optionsGO);
		}

		//draw the credits  button
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.625f,.35f,.1f), creditsSTR))
		{
			swapObjects(creditsGO);
		}				
	
		if(useHighscoreButton)
		{
			if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+0.75f,.35f,.1f), highscoreSTR))
			{
	
				if(RuntimePlatform.IPhonePlayer==Application.platform)
				{
		#if GOT_PRIME31_GAMECENTER
					GameCenterBinding.showLeaderboardWithTimeScope(GameCenterLeaderboardTimeScope.AllTime);
		#endif
				}
			}		
		}
		
		//draw the quit button
		if(useQuitButton)
		{
			if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.875f,.35f,.1f),quitSTR))
			{
				Application.Quit();
			}				
		}
	}
	

}