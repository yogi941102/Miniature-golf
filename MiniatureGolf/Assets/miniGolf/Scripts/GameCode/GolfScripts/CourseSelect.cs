using UnityEngine;
using System.Collections;

public class CourseSelect : BaseMenuState {
	#region variables
	//the background texture
	public Texture backTexture;
	
	//the options menu gameObject
	public GameObject mainMenuGO;
	
	
	public GameObject practiceGO;
	
	//the gui skin
	public GameObject optionsGO;

	//public GUIStyle courseDescStyle;
	
	public string courseSelectBoxSTR =  " Course Select Box";
	public GameScript gameScript;
	public int cousreAIndex = 1;


	
	public string courseADesc = "courseADesc";
	
	public int courseBIndex = 19;

	public string courseBDesc = "courseADesc";

	
	public int cousreCIndex = 37;

	public string courseCDesc = "courseADesc";

	public int cousreDIndex = 55;

	public string courseDDesc = "courseADesc";

	public GUIStyle courseDesc;
	
	public bool showCourseDesc = false;
	#endregion
	
	void Start()
	{
		//lets show the cursor and unlock it (incase it was).
		Screen.lockCursor=false;
		Cursor.visible=true;
	}
	//deactivate this object and active the incoming one.
	void changeGameObject(GameObject go)
	{
		go.SetActive(true);
		gameObject.SetActive(false);
	}
	public override void onGUI()	{
		float offsetX = transform.position.x + MenuConstants.OFFSET_X;
		float offsetY = transform.position.y + MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;
		
		//draw out background texture
		if(backTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect (0,0,1f,1f),backTexture);
		}	
		
		//draw the menu box
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), courseSelectBoxSTR);

				courseDesc.font = guiSkin0.label.font;


		//load level1
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.0725f,.35f,.1f), gameScript.courseNames[0]))
		{
			if(Constants.getPracticeMode()==false)
			{
				Application.LoadLevel(cousreAIndex);
			}else{
				Constants.setCourseIndex(0);
				swapObjects(practiceGO);
			}
		}
		if(showCourseDesc){
			GUI.Label (GUIHelper.screenRect (offsetX+.05f,offsetY+.125f,.35f,.1f), 
				courseADesc,courseDesc);
		}
		//load level 19
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.2f,.35f,.1f), gameScript.courseNames[1]))
		{
			if(Constants.getPracticeMode()==false)
			{
				Application.LoadLevel(courseBIndex);
			}else{
				Constants.setCourseIndex(1);
				swapObjects(practiceGO);
			}
		}
		if(showCourseDesc){		
			GUI.Label (GUIHelper.screenRect (offsetX+.05f,offsetY+.25f,.35f,.1f), 
				courseBDesc,courseDesc);
		}
		//load level 19
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.325f,.35f,.1f),
			gameScript.courseNames[2]))
		{
			if(Constants.getPracticeMode()==false)
			{
				Application.LoadLevel(cousreCIndex);
			}else{
				Constants.setCourseIndex(2);
				swapObjects(practiceGO);
			}

		}
		if(showCourseDesc){		
		
			GUI.Label (GUIHelper.screenRect (offsetX+.05f,offsetY+.375f,.35f,.1f),
				courseCDesc,courseDesc);
		}
		//load level 19
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.45f,.35f,.1f), gameScript.courseNames[3]))
		{
			if(Constants.getPracticeMode()==false)
			{
				Application.LoadLevel(cousreDIndex);
			}else{
				Constants.setCourseIndex(3);
				swapObjects(practiceGO);

			}

		}
		if(showCourseDesc){		
			
			GUI.Label (GUIHelper.screenRect (offsetX+.05f,offsetY+.5f,.35f,.1f), courseDDesc,courseDesc);
		}
		
		//GUI.skin = guiSkin1;
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.5725f,.35f,.1f), "Options"))
		{
			//deactive this object and activate the  menu menu gameObject
			swapObjects(optionsGO);
		}
		
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f), "Main Menu"))
		{
			//deactive this object and activate the  menu menu gameObject
			swapObjects(mainMenuGO);

		}
	}
	
}
