using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
	

	public GUIStyle FowardButton;
	public GUIStyle BackButton;
	public GUIStyle AttackButton;
	public GUIStyle JumpButton;
	public GameObject player;

	Animator anim;
	GroundCheckScript groundChecker;

	float maxSpeed = 10f;
	float groundRadius = 0.2f;
	float speed = 0;
	float i;

	bool facingRight = true;
	float walking;

	void Start()
	{
		groundChecker = player.GetComponent<GroundCheckScript>();
		anim = player.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		print(groundChecker.IsGrounded());
		walking = player.rigidbody2D.velocity.x;
		if(!facingRight)
		{
			walking *= -1;
		}
		anim.SetFloat("Speed", walking);
		if(!anim.GetBool("Ground"))
		{
		}
	}

	void OnGUI()
	{
		if (GUI.RepeatButton (new Rect (Screen.width * .15f,Screen.height * .82f,90,90),"",FowardButton)) 
		{
			player.rigidbody2D.velocity = new Vector2(0.5f * maxSpeed, player.rigidbody2D.velocity.y);
			if(!facingRight)
			{
				Flip();
			}
		}

		if (GUI.RepeatButton( new Rect (Screen.width * .011f,Screen.height * .82f,90,90), "", BackButton))
		{
			player.rigidbody2D.velocity = new Vector2(-0.5f * maxSpeed, player.rigidbody2D.velocity.y);
			walking *= -1;
			if(facingRight)
			{
				Flip();
			}
		}

		if (GUI.Button( new Rect (Screen.width * .70f, Screen.height * .82f,90,90), "", AttackButton))
		{
			StartCoroutine(Attacking());
		}

		if(GUI.Button(new Rect (Screen.width * .85f, Screen.height * .82f,90,90), "", JumpButton))
		{
			player.rigidbody2D.AddForce(new Vector2(0,700f));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = player.transform.localScale;
		theScale.x *= -1;
		player.transform.localScale = theScale;
	}

	IEnumerator Attacking()
	{
		float endTime = Time.time + 0.4f;
		while(Time.time < endTime)
		{
			anim.SetBool("Attack", true);
			yield return new WaitForSeconds(0.3f);
			anim.SetBool("Attack",false);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
