using UnityEngine;
using System.Collections;
/// <summary>
/// The Mini Golf Score state.
/// </summary>
public class ScoreState : BaseMenuState {
	
	#region variables
	
	///a reference to the guitext
	

	/// <summary>
	/// the audio clip to play when the player gets a hole in one.
	/// </summary>
	public AudioClip holeInOneAC;
	
	/// <summary>
	/// the text to display when the player gets a hole in 1.
	/// </summary>
	public string holeInOneSTR = "Hole in one";
	
	/// <summary>
	/// The audio clip to play when the player gets a par or worse.
	/// </summary>
	public AudioClip[] strokeACs;
	
	/// <summary>
	/// A list of strings to display when the player gets a par or worse
	/// </summary>
	public string[] strokeStrings = {"Par",
									"Boogey",
									"Double Boogey",
									"Triple Boogey",
									"Quadruple Boogey",
									"Big Eight!"};
	/// <summary>
	/// The audio clip to play when the player gets birdie or better
	/// </summary>	
	public AudioClip[] negStrokesAC;
	
	/// <summary>
	/// A list of strings to display when the player gets a birdie or better
	/// </summary>	
	public string[] negStrokes = {"Birdie","Eagle","Albatross"};

	//a ref to the game script
	private GameScript m_gameScript;
	
	//our total score check.
//	private int m_totalScore=-1;
	
	/// <summary>
	/// The total par text
	/// </summary>
	public string totalParSTR = "Total Par ";
	/// <summary>
	/// The total score text
	/// </summary>
	public string totalScoreSTR = "Total Score ";
	

	public string nextSceneID = "NextScene";
	private bool m_oneTime=false;

	public GUIText[] scoreGTs = new GUIText[18];
	public GUIText[] parGTs = new GUIText[18];

	#endregion
//	private string m_state;
	public void Start()
	{
		m_on = false;
		//get out gamescript component
		GameObject go = GameObject.FindWithTag("Game");
		if(go)
		{
			m_gameScript = go.GetComponent<GameScript>();
		}
		for(int i=0; i<18; i++)
		{
			string postfix =  (i+1).ToString("00");
			go = GameObject.Find("Hole" + postfix + "gt");

			if(go)
			{
				scoreGTs[i] = go.GetComponent<GUIText>();
				scoreGTs[i].text = "";
			}

			go = GameObject.Find("Par" + postfix);
			if(go)
			{
				parGTs[i] = go.GetComponent<GUIText>();
				parGTs[i].text = "";
			}
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
//		m_state = stateID;
		if(stateID.Equals( GameScript.State.SHOWSCORE.ToString())  )
		{
			MenuStateManager.enterState( m_stateID );
			if(m_oneTime==false)
			{
				GetComponent<AudioSource>().PlayOneShot(getAudioClip());
				m_oneTime=true;
			}
		}else{
//			Debug.Log ("ENTERSTATE" + stateID);
			base.onEnterState(stateID );
		}
	}
	public void Update()
	{
		string stateID = MenuStateManager.CURRENT_STATE.ToUpper();
		
		if( stateID.Contains("SHOWSCORE"))
		{
			if(m_on==false)
			{
				m_on = true;
			}
		}
	}
	void onButtonPress (string id)
	{
		if(id.Equals(nextSceneID))
		{
			//m_on=false;
			//m_done = true;
			Debug.ClearDeveloperConsole();
			Debug.Log ("TURN OFF SCORE STATE");
			m_gameScript.nextScene();
		}
	}
	public GUIText resultGT;
	public GUIText totalGT;
	public override void onGUI()
	{
		float px = transform.position.x;
		float py = transform.position.y;	
		if(m_on)
		{
			Screen.lockCursor=false;
		}

		
		int nomStrokes = m_gameScript.getNomStrokes();
		int totalScore = m_gameScript.getTotalScore();
//		int totalPar = m_gameScript.getTotalPar();
		int par = m_gameScript.getPar();
		int courseIndex = m_gameScript.getCourseIndex();
		


		totalGT.text =  totalScore.ToString();

		int handicap = nomStrokes - par;
		string term = getTerm(nomStrokes,handicap);
		resultGT.text = term;
		//GUI.Box(GUIHelper.screenRect(px+0.51f,py+0.05f,.2f,.1f), term);
		
		
		//if(Constants.getPracticeMode()==false)
		{
			showScore();
		}
	}
	
	public AudioClip getAudioClip()
	{
		int nomStrokes = m_gameScript.getNomStrokes();
		int par = m_gameScript.getPar();
		int handicap = nomStrokes - par;
		
		AudioClip rc = null;
		if(nomStrokes==1)
		{
			rc = holeInOneAC;
		}else{
			if(handicap > -1 && handicap < strokeACs.Length)
			{
				rc = strokeACs[handicap];
			}else
			{
				int invHandicap = (handicap*-1)-1;
//				string str = invHandicap.ToString() + " under par";
				if(invHandicap > -1 && invHandicap<negStrokesAC.Length)
				{
					rc = negStrokesAC[invHandicap];
				}
			}
		}
		return rc;
		
	}
	public string getTerm(int nomStrokes, int handicap)
	{
		string term = "";
		if(nomStrokes==1)
		{
			term = holeInOneSTR;
		}else{
			if(handicap > -1 && handicap < strokeStrings.Length)
			{
				term = strokeStrings[handicap];
			}else
			{
				int invHandicap = (handicap*-1)-1;
//				string str = invHandicap.ToString() + " under par";
				if(invHandicap > -1 && invHandicap<negStrokes.Length)
				{
					term = negStrokes[invHandicap];
				}
			}
		}
		return term;
		
	}
	public void showScore()
	{
		float px = transform.position.x;
		float py = transform.position.y;
		Rect r0 = new Rect(px+0.09f,py+0.35f,.825f,.3f);
		Rect r1 = r0;
		//GUI.Box(GUIHelper.screenRect(r1),"",backgroundBoxStyle);
		float dx = r0.width / 9f;
		float dy = r0.height / 2f;
		
		r1.width = dx;
		r1.height = dy;
		int currentHole = m_gameScript.getHoleNomUsingCourse();
		int n = 1;
		int m = 0;

		for(int i=0; i<2; i++)
		{
			
			for(int j=0; j<2; j++)
			{
				int score = m_gameScript.getTotalScoreAtHole(n);
				int par = m_gameScript.getParForHole(n);
				Rect r2 =r1;

				r2.y += 0.05f;
				
				if (n <= currentHole)
				{
					parGTs[m].text = par.ToString();

					r2.y += 0.05f;

					scoreGTs[m].text = score.ToString();
				}
				r1.x += (dx*1.05f);
				n++;
				m++;
			}
			
			r1.x = r0.x;
			r1.y += dy*1.5f;
		}
	}

}
