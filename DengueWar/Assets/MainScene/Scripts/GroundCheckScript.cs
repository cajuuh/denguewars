using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
	}

	public bool IsGrounded()
	{
		return grounded;
	}
}
