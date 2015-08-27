using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	//Declarando variáveis
	public	bool 		walk;
	public 	Animator 	anima;
	public 	float		maxSpeed;
	public  Rigidbody2D rbPlayer;
	public  int			jumpForce;
	private float 		movimentacaoX;
	private bool		facingRight = true;
	public 	Transform	groundChecker;
	public 	bool		grounded;
	public 	LayerMask	WhatIsGround;
	public  int			jumped = 0;
	public 	bool		doubleJump;
	public  bool		wallcheck;

	// Use this for initialization
	void Start () {
//		anima = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		//maxspeedy = 
		//minspeedy = -3.4
		movimentacaoX = Input.GetAxis ("Horizontal");

		grounded = Physics2D.OverlapCircle (groundChecker.position, 0.2f, WhatIsGround);	

		if (grounded)
			doubleJump = false;	

		if (Input.GetButtonDown ("Jump") && (grounded || !doubleJump)) {

			rbPlayer.velocity = new Vector2(0,0);

			rbPlayer.AddForce(new Vector2(0, jumpForce));
			if (!grounded || !doubleJump)
				doubleJump = true;
		}

		if (movimentacaoX > 0 && !facingRight)
			Flip ();
		else if (movimentacaoX < 0 && facingRight)
			Flip ();

		rbPlayer.velocity = new Vector2 (movimentacaoX * maxSpeed, rbPlayer.velocity.y);

		walk = movimentacaoX != 0;
		anima.SetBool("walk", walk);
		anima.SetBool ("grounded", grounded);
		anima.SetFloat ("speedY", rbPlayer.velocity.y);


		if (grounded)
			jumped = 0;
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 playerScale = transform.localScale;

		playerScale.x *= -1;
		transform.localScale = playerScale;

	}

	void OnTriggerEnter2D(Collider2D collid)	{
//		wallcheck = true;
	}

	void OnTriggerExit2D(Collider2D collid){
		wallcheck = false;
	}

	void OnTriggerStay2D(Collider2D collid){
		wallcheck = true;
	}

	void OnCollisionEnter2D(Collision2D  coll){
		if (coll.gameObject.tag == "bloco")
			Debug.Log ("Bateu em um bloco");
	}

	void OnCollisionExit2D(Collision2D  coll){
		Debug.Log ("Colision Exit 2d");
	}

	void OnCollisionStay2D(Collision2D  coll){
		Debug.Log ("Colision Stay 2d");
	}

}
