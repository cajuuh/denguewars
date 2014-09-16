using UnityEngine;
using System.Collections;

public class Gps : MonoBehaviour {
	float la;
	float lo;
	 void Start() {
		
		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			//yield return new WaitForSeconds(1);
			//maxWait--;
		}
		if (maxWait < 1) {
			print("Timed out");
			//return;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
						print ("Unable to determine device location");
						//return;
				} else
						la = Input.location.lastData.latitude;
						lo = Input.location.lastData.longitude;
			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		Input.location.Stop();
	}

	public float getLa(){
		return la;
	}
	public float getLo(){
		return lo;
	}
}