using UnityEngine;
using System.Collections;
/// <summary>
/// A constraint that will look this in on the x-axis.
/// </summary>
public class Constraint : MonoBehaviour {
	/// <summary>
	/// The constraint x.
	/// </summary>
	public bool constraintX = false;

	/// <summary>
	/// Do we want to use a y-constraint.
	/// </summary>
	public bool constraintY = false;
	
	public bool constraintZ = false;
	/// <summary>
	/// The x axis.
	/// </summary>
	public Vector2 xAxis = new Vector2(-10,10);
	
	/// <summary>
	/// The y axis constraint
	/// </summary>
	public Vector2 yAxis = new Vector2(0,40);
	/// <summary>
	/// The y axis constraint
	/// </summary>
	public Vector2 zAxis = new Vector2(0,40);
	void LateUpdate () {
		Vector3 pos = transform.position;
		if(constraintX)
		{
			pos.x = Mathf.Clamp(pos.x,xAxis.x,xAxis.y);
		}
		if(constraintY)
		{
			pos.y = Mathf.Clamp(pos.y,yAxis.x,yAxis.y);
		}
		if(constraintZ)
		{
			pos.z = Mathf.Clamp(pos.z,zAxis.x,zAxis.y);
		}
		
		transform.position = pos;
	}
}
