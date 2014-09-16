using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public float barDisplay;
	public int playerScore = 0;
	public Font font;
	public GameObject player;
	public GUIStyle style;
	public GUIStyle progress_empty;
    public GUIStyle progress_full;
    Vector2 pos = new Vector2(10,20);
    Vector2 size = new Vector2(100,20);
    ArrowScript pHealth;

    public Texture2D emptyTex;
    public Texture2D fullTex;

    float timer = 50f;

	void Start()
	{
		pHealth = player.GetComponent<ArrowScript>();
		style.font = font;
		style.normal.textColor = Color.white;
	}

	void Update()
	{
		timer -= Time.deltaTime;
		barDisplay = pHealth.playerHealth;
		if(timer <= 0f)
		{
			Application.LoadLevel(4);
		}
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), emptyTex, progress_empty);
		GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), fullTex, progress_full);

		GUI.BeginGroup(new Rect(0, 0, barDisplay, size.y));
		GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);

		GUI.EndGroup();
		GUI.EndGroup();

		GUI.Label(new Rect(Screen.width * .5f, Screen.height * .05f, 90, 90), "" + timer.ToString("0"), style);

		GUI.Label(new Rect(Screen.width * .85f, Screen.height * .05f,90,90), "Score: " + playerScore, style);
	}

}
