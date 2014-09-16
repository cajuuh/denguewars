using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	SpriteRenderer tutoSpriteRenderer;
	GameObject tutoGO;
	public GameObject mainCamera;

	void Start()
	{
		tutoSpriteRenderer = GameObject.Find("tutorial1").GetComponent<SpriteRenderer>();
		tutoGO = GameObject.Find("tutorial1");

	}

	void FixedUpdate()
	{
		tutoGO.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y+1.5f, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			tutoSpriteRenderer.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")	
		{
			tutoSpriteRenderer.enabled = false;
		}
	}
}
