using UnityEngine;
using System.Collections;

public class ArrowScriptLeft : MonoBehaviour {

	float maxSpeed = 10f;
	int CountTouchLeft;
	float fixTime;
	Touch timeTouching;
	public GameObject Player;

	void Start()
	{
	}

	void Update () 
	{
		CountTouchLeft = Input.touchCount;
		Debug.Log(CountTouchLeft);
		fixTime = timeTouching.deltaTime;
		if(fixTime > 1f)
		{
			fixTime = 1f;
		}
	}

	void FixedUpdate()
	{
		Player.rigidbody2D.velocity = new Vector2(fixTime*maxSpeed, Player.rigidbody2D.velocity.y);
	}
}
