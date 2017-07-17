using UnityEngine;
using System.Collections;

public class MenuStartup : MonoBehaviour {

	public GameObject practiceGO;
	public GameObject mainGO;
	
	void Start () {
		Time.timeScale=1;
/*		if(MainMenuState.START_UP)
		{
			if(Constants.getPracticeMode())	
			{
				practiceGO.SetActive(true);
			}else{
				mainGO.SetActive(true);
			}
		}else{
			mainGO.SetActive(true);
		}*/
	}
	
	
}
