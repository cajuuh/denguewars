using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
	
	public GUITexture touchButton;
	public GameObject player;

	void Update () 
	{
		if(touchButton.HitTest(Input.GetTouch(0).position))
		{
			if(Input.GetTouch(0).phase == TouchPhase.Stationary)
			{
				//player.rigidbody2D.velocity = (2*5, player.rigidbody2D.velocity.y);
			}
		}
	}
}
