using UnityEngine;
using System.Collections;

public class aula : MonoBehaviour {

	//Declarando variáveis
	public	bool 		walk;
	public 	Animator 	anima;
	public 	float		maxSpeed;
	public  Rigidbody2D rbPlayer;
	private float 		movimentacaoX;
	private bool		facingRight = true;  

	// Use this for initialization
	void Start () {
//		anima = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		movimentacaoX = Input.GetAxis ("Horizontal");

		if (movimentacaoX > 0 && !facingRight)
			Flip ();
		else if (movimentacaoX < 0 && facingRight)
			Flip ();

		rbPlayer.velocity = new Vector2 (movimentacaoX * maxSpeed, 0);

		walk = movimentacaoX != 0;
		anima.SetBool("walk", walk);
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 playerScale = transform.localScale;

		playerScale.x *= -1;
		transform.localScale = playerScale;

	}
}
