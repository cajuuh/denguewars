using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 1.2f;
	public bool facingRight = true;
	public GUITexture touchButton;
	int calculator;
	
	CNJoystick stick;

	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		if(Input.touchCount > 0 && touchButton.HitTest(Input.GetTouch(0).position))
		{
			if(Input.GetTouch(0).phase == TouchPhase.Stationary)
			{
				print("apertou");
			}
		}
	}
	void Update () 
	{
	}
}
