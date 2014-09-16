using UnityEngine;
using System.Collections;

public class KhomarScript : MonoBehaviour {

	public GameObject khomarEnemy;

	Animator khomarEnemyAnim;
	ScoreScript scoreChanger;

	int khomarHealth = 2;
	int scoreControl;

	bool onSight;

	void Start()
	{
		scoreChanger = GameObject.Find("Main Camera").GetComponent<ScoreScript>();
		khomarEnemyAnim = khomarEnemy.GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//print("entrou no trigger");
		if(collision.tag == "Player")
		{
			onSight = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			onSight = false;
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player" && (khomarEnemyAnim.GetBool("Attack") == true))
		{
			khomarHealth -= 1;
		}
	}
	
	void FixedUpdate ()
	{
		if(onSight)
		{
			transform.position = Vector3.MoveTowards(transform.position, khomarEnemy.transform.position, .03f);
			if(transform.position.x < khomarEnemy.transform.position.x)
			{
				transform.rotation = Quaternion.AngleAxis(180, Vector2.up);
			}
			else
			{
				transform.rotation = Quaternion.identity;	
			}
		}

		if(khomarHealth == 0)
		{
			scoreChanger.playerScore += 100;
			Destroy(gameObject);
		}
	}
}
