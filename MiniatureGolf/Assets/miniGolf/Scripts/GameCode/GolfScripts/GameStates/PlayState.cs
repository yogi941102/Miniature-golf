using UnityEngine;
using System.Collections;

/// <summary>
/// Mini Golf Play state.
/// </summary>
public class PlayState : BaseMenuState {
	#region variables
	//a ref of the gamescript
	private GameScript m_gameScript;
	
	public GUIText holeGT;
	public GUIText scoreGT;

	public string buttonID;
#endregion
	void Start()
	{
		
		m_gameScript = (GameScript)GameObject.FindObjectOfType(typeof(GameScript));		
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
//		m_state = stateID;
		if(stateID.Equals( GameScript.State.PLAY.ToString()) ||
			stateID.Equals( GameScript.State.WATER_HAZARD.ToString())||
			stateID.Equals( GameScript.State.ROLL.ToString())  )
		{
			MenuStateManager.enterState( m_stateID );

		}else{
			base.onEnterState(stateID );
		}
	}
	void onButtonPress (string id)
	{
		if(id.Equals(buttonID))
		{
			GameManager.enterState(GameScript.State.PAUSE.ToString());
			GameConfig.setPaused(true);
		}
	}

	public override void onGUI()
	{
		//if(m_on==false)return;
		float px = transform.position.x;
		float py = transform.position.y;
		
		GUI.skin = guiSkin0;
		//display the hole #
		int holeIndex = m_gameScript.getHoleNomUsingCourse();
		if(holeGT)
		{
			holeGT.text = holeIndex.ToString();
		}


		
		//display the number of strokes.
		int nomStrokes = m_gameScript.getNomStrokes();		
		if(scoreGT)
		{
			scoreGT.text = nomStrokes.ToString();
		}


		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameManager.enterState(GameScript.State.PAUSE.ToString());
			GameConfig.setPaused(true);
		}
	}

}
