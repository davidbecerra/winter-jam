using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenIdlingController : MonoBehaviour {

	// create animator variable
	Animator PenguinAnimator;


	// Use this for initialization
	void Start () {
		// import the animator component
		PenguinAnimator = GetComponent<Animator>();

		PenguinAnimator.SetTrigger("Idling");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
