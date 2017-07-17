using UnityEngine;
using System.Collections;

/// <summary>
/// A simple Credit Menu state.
/// </summary>
public class CreditState : BaseMenuState 
{	
	#region variables
	/// <summary>
	/// A ref to the main menu GameObject
	/// </summary>
	public GameObject mainMenuGO;
	
	/// <summary>
	/// A ref to the background texture
	/// </summary>
	public Texture backgroundTexture;
	
	/// <summary>
	/// The fade time for the credits.
	/// </summary>
	public float fadeTime = 1f;
	
	private float m_fadeTime;
	//our current title
	private int m_index=0;
	
	/// <summary>
	/// both jobs and authors should be the same number of strings!
	/// </summary>
	public string[] jobs = {"Programmer","Artist"};

	/// <summary>
	/// A list of workers.
	/// </summary>
	public string[] workers = {"Justin","Ivan"};

	#endregion

	public void Start()
	{
		m_index=0;
	
		//call roll credits
//		StartCoroutine(rollCredits());
	}
	void Update()
	{
		m_fadeTime-=Time.deltaTime;
		if(m_fadeTime<0)
		{
			m_fadeTime=fadeTime;
			int n = jobs.Length;
			m_index++;
//			Debug.Log ("Index"+m_index);
			if(m_index>=n)
			{
				m_index=0;
			}
		}
	}
	
	
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x+ MenuConstants.OFFSET_X;
		float offsetY = transform.position.y +MenuConstants.OFFSET_Y;
		
		if(backgroundTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture);
		}
		if(m_done)
		{
			GUI.Label( GUIHelper.screenRect(0.55f,0.4f,.6f,.1f),jobs[m_index]);
			GUI.Label( GUIHelper.screenRect(0.575f,0.5f,.6f,.1f),workers[m_index]);
		}
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), "Credits");
		
		if( GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f) ," Main Menu"))
		{
			
			//deactivate this object and activate teh main menu object
			swapObjects(mainMenuGO);
			
		}
	}
	

	
}
