//#define GOT_PRIME31_GAMECENTER


using UnityEngine;
using System.Collections;

///this menu is displayed when the gamescript is in show score state
public class SubmitState : BaseMenuState {
	
	#region variables
	///have we already subbmited the score
//	private bool m_submittedScore=false;
	///a ref to the gamescript
	private GameScript m_gameScript;
	
	///the name of the player!
	public string playerName = "InaneGamer";

	public string submitID = "Submit";
	public string returnToMainID = "MainMenu";


	/// <summary>
	/// The achivement ids
	/// </summary>
	public AchivementEx[] achivements;
	#endregion
	
	public void Start()
	{
		//get out gamescript component
		GameObject go = GameObject.FindWithTag("Game");
		if(go)
		{
			m_gameScript = go.GetComponent<GameScript>();
		}
	}
	

	void submitScore(int playerScore)
	{
#if GOT_PRIME31_GAMECENTER
		AchivementEx[] achievementResults = AchivementEx.getAchivements(achivements,playerScore,Constants.getCourseIndex());
		if(achievementResults!=null)
		{
			for(int i=0; i<achievementResults.Length; i++)
			{
				GameCenterBinding.reportAchievement(achievementResults[i].achivementID,100f);
			}
		}
#endif
		
#if GOT_PRIME31_GAMECENTER

		GameCenterBinding.reportScore( playerScore, 
				leaderBoardIDs[Constants.getCourseIndex()] );
#endif
		
	}
	public override void OnEnable()
	{
		GameManager.onEnterState += onEnterState;
		BaseGameManager.onButtonPress += onButtonPress;

		base.OnEnable();
	}
	public override void OnDisable()
	{
		GameManager.onEnterState -= onEnterState;
		BaseGameManager.onButtonPress -= onButtonPress;

		base.OnDisable();
	}
	public override void onEnterState(string stateID)
	{
		if(stateID.Equals( GameScript.State.SUBMTSCORE.ToString()) )
		{
			MenuStateManager.enterState( m_stateID );

		}else if(stateID.Equals( GameScript.State.PLAY.ToString())==false)
		{
			base.onEnterState(stateID );
		}
	}
	void onButtonPress (string id)
	{
		int totalScore = m_gameScript.getTotalScore();

		if(id.Equals(submitID))
		{
			submitScore(totalScore);
		}

		if(id.Equals(returnToMainID))
		{
			//return to the main menu!
			m_gameScript.returnToMain();
		}
	}

	public GUIText usernameGT;
	public GUIText totalScoreGT;
	public GUIText totalParGT;
	public override void onGUI()
	{
		float px = transform.position.x;
		float py = transform.position.y;
				GUI.skin = guiSkin0;
		//display the box
		int courseIndex = m_gameScript.getCourseIndex();
		string userName = playerName;
		int totalScore = m_gameScript.getTotalScore();
		int totalPar = m_gameScript.getTotalPar();
		if(RuntimePlatform.IPhonePlayer == RuntimePlatform.IPhonePlayer)
		{
#if GOT_PRIME31_GAMECENTER
			userName = GameCenterBinding.playerAlias();
#endif
		}

		usernameGT.text = userName;
		totalScoreGT.text = totalScore.ToString();
		totalParGT.text = totalPar.ToString();

	}
	

}