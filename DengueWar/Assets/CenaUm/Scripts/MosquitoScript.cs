using UnityEngine;
using System.Collections;

public class MosquitoScript : MonoBehaviour {

	public GameObject mosquitoEnemy;
	public float mosquitoVelocity = 2f;
	SpriteRenderer mosquitoSprite;
	public int mosquitoHealth = 3;
	public int sentinel = 0;
	//ScoreScript playerScore;
	GameObject clone;

	void Start ()
	{
		clone = GameObject.Find("MosquitoEnemy(Clone)");
		//playerScore = GameObject.Find("Main Camera").GetComponent<ScoreScript>();
		mosquitoSprite = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		//follow the player
		transform.position = Vector3.MoveTowards(transform.position, mosquitoEnemy.transform.position, .03f);
		if(transform.position.x < mosquitoEnemy.transform.position.x)
		{
			transform.rotation = Quaternion.AngleAxis(180, Vector2.up);
		}
		else
		{
		transform.rotation = Quaternion.identity;	
		}

		//kill the mosquito
		if(mosquitoHealth == 0)
		{
			Destroy(clone);
			//playerScore.playerScore++;
			sentinel = 1;
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Bullet")
		{
			StartCoroutine(Blink(1.0f));
			Destroy(collision.gameObject);
			mosquitoHealth--;
		}
	}

	//blinking coroutine
	IEnumerator Blink(float waitTime)
	{
		float endTime = Time.time + waitTime;
		while(Time.time < endTime)
		{
			mosquitoSprite.enabled = false;
			yield return new WaitForSeconds(0.1f);
			mosquitoSprite.enabled = true;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
