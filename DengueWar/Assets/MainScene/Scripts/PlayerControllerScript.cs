using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 1.2f;
	public bool facingRight = true;
	int calculator;
	
	CNJoystick stick;

	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
	}
	void Update () 
	{
	}
}
