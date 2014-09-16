using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public GameObject mainCam;
	ArrowScript playerH;

	void Start()
	{
		playerH = mainCam.GetComponent<ArrowScript>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			playerH.playerHealth += 10;
			Destroy(gameObject);
		}
	}
}
