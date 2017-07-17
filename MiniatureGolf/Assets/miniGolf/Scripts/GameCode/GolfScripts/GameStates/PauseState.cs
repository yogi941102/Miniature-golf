using UnityEngine;
using System.Collections;
/// <summary>
/// Mini Golf Pause state.
/// </summary>
public class PauseState : BaseMenuState {
	#region variables	
	public string resumeID = "Resume";
	public string giveUpID = "Give Up";
	public string returnToMainID = "Return To Main";

	/// a ref to our gamescript
	private GameScript m_gameScript;
	
	private string m_prevState = "";
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
	void onButtonPress (string id)
	{
		if(id.Equals(resumeID))
		{
			GameManager.enterState(m_prevState);
			m_gameScript.resume();
		}
		if(id.Equals(giveUpID))
		{
			//give up!
			m_gameScript.giveUp();
		}
		if(id.Equals(returnToMainID))
		{
			//return to the main menu!
			m_gameScript.returnToMain();
		}
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
		if(stateID.Equals( GameScript.State.PAUSE.ToString()) )
		{

			MenuStateManager.enterState( m_stateID );
		
		}else{
			base.onEnterState(stateID );
		}
	}
	
	
	public override void onGUI()
	{
	//	if(m_on==false)return;
		float px = transform.position.x;
		float py = transform.position.y;
		

	}

}
