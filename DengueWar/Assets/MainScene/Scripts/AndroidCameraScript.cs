using UnityEngine;
using System.Collections;

public class AndroidCameraScript : MonoBehaviour {

	public GUIStyle CameraButton;
	WebCamTexture mCamera;
    public GameObject plane;
 

    void Start ()
    {
    	Debug.Log ("Script has been started");
    	mCamera = new WebCamTexture ();
    	plane.renderer.material.mainTexture = mCamera;
    	mCamera.Play ();
    }

    void Update()
    {
    }

    void OnGUI()
    {
    	if(GUI.Button( new Rect (Screen.width * .02f, Screen.height * .5f,90,90), "", CameraButton))
    	{
    		Application.CaptureScreenshot("DengueWarsScreen.png");
            Application.LoadLevel(1);
    	}
    }
}
