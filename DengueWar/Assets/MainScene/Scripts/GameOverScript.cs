using UnityEngine;
using System.Collections;


public class GameOverScript : MonoBehaviour 
{
	public GUIStyle RestartButton;

	void OnGUI()
	{
		if (GUI.Button( new Rect (Screen.width * .45f, Screen.height * .82f,90,90), "", RestartButton))
		{
			Application.LoadLevel(1);
		}	
	}
}
