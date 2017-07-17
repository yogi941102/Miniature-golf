using UnityEngine;
using System.Collections;

/// <summary>
/// Menu state manager.
/// </summary>
public class MenuStateManager  {
	public static string CURRENT_STATE = "";
	public delegate void OnEnterState(string stateID);
	public static event OnEnterState onEnterState;
	public static void enterState(string stateID)
	{
		CURRENT_STATE = stateID;
		if(onEnterState!=null)
		{
			onEnterState(stateID);
		}
	}
	public static void enterStateUsingName(string name)
	{
		
		BaseMenuState bms = getState(name);
		if(bms)
		{
			CURRENT_STATE = bms.getStateID();
			if(onEnterState!=null)
			{
				onEnterState(bms.getStateID());
			}
		}
	}

	public static void enterStateUsingGameObject(GameObject go)
	{
		BaseMenuState bms = getState(go);
		if(bms)
		{
			CURRENT_STATE = bms.getStateID();
			if(onEnterState!=null)
			{
				onEnterState(bms.getStateID());
			}
		}
	}
	public static BaseMenuState getState(GameObject go)
	{
		BaseMenuState bms = null;
		if(go){
			bms = go.GetComponent<BaseMenuState>();
		}
		return bms;
	}	
	public static BaseMenuState getState(string name)
	{
		BaseMenuState bms = null;
		GameObject go = GameObject.Find(name);
		if(go){
			bms = go.GetComponent<BaseMenuState>();
		}
		return bms;
	}
}
