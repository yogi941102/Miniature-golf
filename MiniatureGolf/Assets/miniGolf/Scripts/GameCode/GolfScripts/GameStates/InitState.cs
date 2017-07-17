using UnityEngine;
using System.Collections;

/// <summary>
/// Mini Golf Init state.
/// </summary>
public class InitState : BaseMenuState {
	
	#region variables
	public GUIText holeGT;
	
	private GameScript m_gameScript;

	public string startID = "start";
	#endregion
	void Start()
	{

		m_gameScript = (GameScript)GameObject.FindObjectOfType(typeof(GameScript));		
		m_on=true;
		m_dir=1;
		m_done = true;
	}

	public override void OnEnable()
	{
		GameManager.onEnterState += onEnterState;
		BaseGameManager.onButtonPress += onButtonPress;
		base.OnEnable();
	}

	void onButtonPress (string id)
	{
		if(id.Equals(startID))
		{
			GameManager.enterState( GameScript.State.PLAY.ToString());
		}
	}
	public override void OnDisable()
	{
		GameManager.onEnterState -= onEnterState;
		BaseGameManager.onButtonPress -= onButtonPress;

		base.OnDisable();
	}


	public override void onEnterState(string stateID)
	{
		if(stateID.Equals( GameScript.State.INIT.ToString()) )
		{
			MenuStateManager.enterState( m_stateID );
		}else{
			base.onEnterState(stateID );
		}
	}
	
	public override void onGUI()
	{
		//if(m_on==false)return;
		float px = transform.position.x;
		float py = transform.position.y;
		GUI.skin = guiSkin0;
		
		//ge the currently loaded level (which acts as our current hole)!
		int holeIndex = m_gameScript.getHoleNomUsingCourse();
		holeGT.text = holeIndex.ToString();

		
		
	}
}
