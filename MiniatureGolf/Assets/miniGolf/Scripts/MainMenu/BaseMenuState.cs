using UnityEngine;
using System.Collections;
/// <summary>
/// Base menu state.
/// </summary>
public class BaseMenuState : MonoBehaviour {
	/// <summary>
	/// The time it takes to move the transform from the start to end location
	/// </summary> 
	public float moveTime = .5f;

	private float m_moveTime = 0;
	/// <summary>
	/// The start position of the transform.
	/// </summary>
	public Vector3 startPos = new Vector3(-1,0,0);
	/// <summary>
	/// The end position of the transform.
	/// </summary>
	public Vector3 endPos = new Vector3(0,0,0);
	protected bool m_done = true;
	
	protected float m_dir = 1;
	
	protected string m_stateID;
	
	/// <summary>
	/// Is the menu on
	/// </summary>
	public bool m_on = false;
	public GUISkin guiSkin0;
	
	/// <summary>
	/// Is the menu always on.
	/// </summary>
	public bool alwaysOn = false;
	
	/// <summary>
	/// Do we want to lock the cursor when we enter the state.
	/// </summary>
	public bool lockCursor = false;	

	public enum StateType
	{
		FiniteStateMachine,
		TimedState
	};
	public StateType stateType = StateType.FiniteStateMachine;

	public float showTime = 1f;
	private TouchButton[] m_buttons;
	public void Awake(){
		//m_buttons = gameObject.GetComponentsInChildren<TouchButton>();
		m_stateID = gameObject.name;

		if(m_on==false)
			transform.position = startPos;
		//setActiveButtons(m_on);
	}
	public virtual void OnEnable()
	{
		MenuStateManager.onEnterState += onEnterState;
	}
	public virtual  void OnDisable()
	{
		MenuStateManager.onEnterState -= onEnterState;
	}
	public string getStateID()
	{
		return m_stateID;
	}

	public IEnumerator toggleState()
	{
		if(m_on==false)
		{
			enable();
		}
		m_on = true;
		yield return new WaitForSeconds(showTime);
		disable();
	}
	public virtual void onEnterState(string sid)
	{
		if(stateType == StateType.TimedState )
		{
			if(m_stateID.Equals(sid)){
				StartCoroutine(toggleState());
			}
		}
		else if(stateType == StateType.FiniteStateMachine)
		{
			if(m_stateID.Equals(sid))
			{

				if(m_on==false)
				{
					Debug.Log ("state " +sid);

					enable();
				}
				
				m_on = true;
			}else{
				if(m_on)
				{
					Debug.Log ("disable state " +m_stateID);

					disable();
				}

			}
		}
	}
	public void OnGUI()
	{
		if(m_on || alwaysOn)
		{
			onGUI();
		}
	}
	public virtual void onGUI(){}
	
	public void swapObjects(GameObject go)
	{
		MenuStateManager.enterStateUsingGameObject( go );
	}

	void enable()
	{
		if(m_done)
		{
			m_on=true;
			m_dir=1;
			m_done = false;
			m_moveTime=0;
			m_moveTime = Time.realtimeSinceStartup; 
			Screen.lockCursor = lockCursor;
			transform.position = startPos;

		}
	}
	void setActiveButtons(bool active)
	{
		for(int i=0; i<m_buttons.Length; i++)
		{
			m_buttons[i].gameObject.SetActive(active);
		}
	}
	public void disable(int cmd=-1)
	{
		m_done = false;
		m_moveTime = 0 + Time.realtimeSinceStartup;
		m_dir=-1;
		transform.position = endPos;

	}
	void LateUpdate()
	{
		if(m_done==false)
		{
			float v = Time.realtimeSinceStartup - m_moveTime;
			float val = v / moveTime;

			if(val>1 )
			{
				val = 1;
				m_done = true;
				if(m_dir==-1)
				{
					m_on = false;
				}
			}
			if(m_dir>0)
			{
				transform.position = Vector3.Lerp(startPos,endPos,val);
			}else{
				transform.position = Vector3.Lerp(endPos,startPos,val);
			}
		}
	}

}
