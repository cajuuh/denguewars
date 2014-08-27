using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	public bool facingRight = true;
	
	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
	}

	void Update () 
	{
		
	}
}
