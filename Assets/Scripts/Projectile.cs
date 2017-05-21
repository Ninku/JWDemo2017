using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


	public int rangeInSeconds = 1;

	private float speed = 2;


	void Update () {
		transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Asteroid"){
			Asteroid a = col.gameObject.GetComponent<Asteroid>();
			a.Breakup();
			Destroy(gameObject);
		}
	}

}
