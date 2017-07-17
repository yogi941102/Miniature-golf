using UnityEngine;
using System.Collections;
/// <summary>
/// Practice mode.
/// </summary>
public class PracticeMode : BaseMenuState
{
	/// <summary>
	/// The textures.
	/// </summary>
	public Texture[] textures;

	/// <summary>
	/// The back texture.
	/// </summary>
	public Texture backTexture;
	
	/// <summary>
	/// A main menu gameObject
	/// </summary>
	public GameObject mainMenuGO;

	/// <summary>
	/// A ref to the game script.
	/// </summary>
	public GameScript gameScript;
	
	/// <summary>
	/// The practice menu text
	/// </summary>
	public string practiceMenuSTR = "Practice Menu";
	
	/// <summary>
	/// The main menu text
	/// </summary>
	public string mainMenuSTR = "Course Select";
	
	/// <summary>
	/// The course gui style
	/// </summary>
	public GUIStyle courseGS;
	
	/// <summary>
	/// The course button  gui style
	/// </summary>
	public GUIStyle courseButtonGS;
	
	/// <summary>
	/// The level guiStyle
	/// </summary>
	public GUIStyle levelGS;
	
	/// <summary>
	/// The level indexes.
	/// </summary>
	public int[] levelIndexes = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,
								21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,
								38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55};
	
	
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
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.9f,.89f), practiceMenuSTR);
		
		courseGS.font = guiSkin0.label.font;
		courseButtonGS.font = guiSkin0.button.font;
		GUI.Label(GUIHelper.screenRect (offsetX,offsetY+0.05f,.9f,.89f),
			gameScript.courseNames[Constants.getCourseIndex()],courseGS);
			
		levelGS.font = guiSkin0.label.font;
		Rect r1 = new Rect(offsetX+0.05f-(2.5f*0.0125f),offsetY+0.2f,0.8f,0.6f);
		int n =1;
		int m = 0;
		Rect r2 = r1;
		float dx = r1.width / 6f;
		float dy = r1.height / 3f;	
		r2.width=dx;
		r2.height = dy;
		for(int i=0; i<3; i++)
		{
			for(int j=0; j<6; j++)
			{
				int levelIndex = n+ Constants.getCourseIndex()*18;
				if(GUI.Button(GUIHelper.screenRect(r2),textures[levelIndex-1],
					courseButtonGS))
				{
					
					Application.LoadLevel( levelIndexes[Constants.getCourseIndex()*18+m]);
				}
				GUI.Label(GUIHelper.screenRect(r2),"Level" + n,levelGS);
				r2.x += dx + 0.0125f;
				m++;
				n++;
			}
			r2.x = r1.x;
			r2.y += dy+0.025f;
		}
		if( GUI.Button (GUIHelper.screenRect (offsetX+.25f,offsetY+.775f,.4f,.1f) ,
			mainMenuSTR))
		{	
			//deactivate this object and activate teh main menu object
			swapObjects(mainMenuGO);
		}
	}

}
