using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fader : MonoBehaviour {

	public bool fadeInCompleted = false;

	private Animator anim;


	void Start () {
		anim = GetComponent<Animator>();
	}

	public void StartFadeOut(){
		gameObject.SetActive(true);
		anim.Play("FadeOut");
	}

	public void FadeInCompleted(){
		fadeInCompleted = true;
	}
		
}
