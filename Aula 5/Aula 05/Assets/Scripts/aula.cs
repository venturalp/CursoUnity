using UnityEngine;
using System.Collections;

public class aula : MonoBehaviour {

	//Declarando variáveis
	public	bool walk;
	public Animator anima;

	// Use this for initialization
	void Start () {
//		anima = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") != 0) {
			//if (Input.GetAxis ("Horizontal") == -1) 
			walk = true;
		} else {
			walk = false;
		}

		anima.SetBool("walk", walk);
	}
}
