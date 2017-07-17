using UnityEngine;
using System.Collections;
/// <summary>
/// The Stage select Menu
/// </summary>
public class StageSelect : BaseMenuState {

	#region variables
	
	/// <summary>
	/// The offset.
	/// </summary>
	public Vector2 offset;

	/// <summary>
	/// A ref to the main menu gameObject
	/// </summary>
	public GameObject mainMenuGO;
	
	/// <summary>
	/// The background texture.
	/// </summary>
	public Texture backgroundTexture;
	
	
	/// <summary>
	/// The number of levels per row
	/// </summary>
	public int levelsPerRow = 3;
	
	/// <summary>
	/// The number of  levels per col
	/// </summary>
	public int levelsPerCol = 4;

	private int m_maxPages = 0;
	
	private int m_page = 0;
	
	/// <summary>
	/// The maximum number of levels
	/// </summary>
	public int maxLevels = 30;
	
	/// <summary>
	/// The stage select text.
	/// </summary>
	public string stageSelectSTR = "Stage Select";
	
	/// <summary>
	/// The level prefix.
	/// </summary>
	public string levelPrefix = "Level ";
	
	/// <summary>
	/// The main menu button text
	/// </summary>
	public string mainMenuButtonSTR = "Main Menu";
	
	/// <summary>
	/// The next page button text.
	/// </summary>
	public string nextPageButtonSTR = ">>";

	/// <summary>
	/// The previous page button text.
	/// </summary>
	public string prevPageButtonSTR = "<<";
	
	
	/// <summary>
	/// The size of the level button in screen coordinate (0..1).
	/// </summary>
	public Vector2 levelButtonSize = new Vector2(0.2f,0.1f);
	
	/// <summary>
	/// The button space offset.
	/// </summary>
	public Vector2 buttonSpaceOffset;
	
	/// <summary>
	/// Do we want use level names or not
	/// </summary>
	public bool useLevelNames=false;
	
	/// <summary>
	/// The level names.
	/// </summary>
	public string[] levelNames = {"Box Runner","Warp and Run"};
	
	/// <summary>
	/// Do we want to lock the levels until they unlock them.
	/// </summary>
	public bool dontLockLevels = false;
	#endregion
	public void Start()
	{
		int n = 0;
		while(n < maxLevels)
		{
			m_maxPages++;
			n+= (levelsPerCol * levelsPerRow);
		}
	}
	public int noffset = 0;
	
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x + offset.x;
		float offsetY = transform.position.y + offset.y;
		
		if(backgroundTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture);
		}
				GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,"");
		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,stageSelectSTR + "\n Number of mini games:" + maxLevels );
		
		int n = 1 + m_page * levelsPerCol * levelsPerRow;
		int q = n;
		for(int i=0; i<levelsPerRow; i++)
		{
			for(int j=0; j<levelsPerCol; j++)
			{
				int levelX = n;
				string str = levelPrefix + levelX.ToString();
				if(useLevelNames && n-1 < levelNames.Length)
				{
					str = levelNames[n-1];	
				}
				if(n<=maxLevels)
				{
					if(n <= Misc.getMaxLevel() || dontLockLevels)
					{
						GUI.enabled=true;
						if( GUI.Button (GUIHelper.screenRect (offsetX+.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
												offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
												levelButtonSize.x,levelButtonSize.y) ,
							str))
						{
							Application.LoadLevel(q);
						}
					}else{
						GUI.enabled=false;
						GUI.Button (GUIHelper.screenRect (offsetX+.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
													offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
													levelButtonSize.x,levelButtonSize.y) ,
							str);					
					}
					n++;
					q+=noffset;
				}
			}
		}
		GUI.enabled=true;
		//only show if we have more tahn 1 page.
		if(m_maxPages>1)
		{
			if( GUI.Button (GUIHelper.screenRect (offsetX+0.05f,offsetY+.325f,.15f,.1f) ,prevPageButtonSTR))
			{
				m_page--;
				if(m_page<0)
				{
					m_page = m_maxPages-1;
				}	

			}
			if( GUI.Button (GUIHelper.screenRect (offsetX+.7f,offsetY+.325f,.15f,.1f) ,nextPageButtonSTR))
			{
				m_page++;
				if(m_page>m_maxPages-1)
				{
					m_page = 0;
				}
			}	
		}
		
		
		if( GUI.Button (GUIHelper.screenRect (offsetX+.3f,offsetY+.45f,.3f,.1f) ,mainMenuButtonSTR))
		{
			
			swapObjects(mainMenuGO);
		}
	}
	
}
