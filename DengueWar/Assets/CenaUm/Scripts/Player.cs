using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade;
	public Transform player;

	//public bool isGrounded;
	public bool jumped;

	private Animator animator;

	public float jumpTime = 1f;
	public float jumpDelay = 1f;
	public float force;

	public Transform ground;



	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar ();
	}

	void Movimentar(){
		//isGrounded = Physics2D.Linecast (this.transform.position, ground.position, 1 << LayerMask.NameToLayer ("Plataforma"));

		animator.SetFloat ("run", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if(Input.GetAxisRaw("Horizontal") > 0){
			transform.Translate(Vector2.right * velocidade  * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
	} 
		if(Input.GetAxisRaw("Horizontal") < 0){
			transform.Translate(Vector2.right * velocidade  * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		} 

		if(Input.GetButtonDown("Jump") && !jumped ){
			rigidbody2D.AddForce(transform.up * force);
			jumpTime = jumpDelay;
			jumped = true;
}
		jumpTime -= Time.deltaTime;
		if(jumpTime<= 0 && jumped){
			jumped=false;
}
}
}