using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour
{
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(2);
		}
	}
}
