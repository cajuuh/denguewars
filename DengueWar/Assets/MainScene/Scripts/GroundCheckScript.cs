using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	ArrowScript health;

	Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		health = GameObject.Find("Main Camera").GetComponent<ArrowScript>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Khomar")
		{
			health.playerHealth -= 10;
		}
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
