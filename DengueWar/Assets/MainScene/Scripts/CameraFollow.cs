using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	float trackingSpeed = 2.0f;
	float zoomSpeed = 5.0f;
	// Use this for initialization
	void Start () {
		if (player == null)
			player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		var pos = player.position;
		pos.y = transform.position.y;
		pos.z = -10;

		transform.position = Vector3.Lerp(transform.position, pos, trackingSpeed * Time.deltaTime);
		//camera.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
	}
}
