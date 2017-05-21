using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	private float speed = 0.90f;

	void Update () {
		transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

	void OnCollisionEnter2D(){
		Destroy(gameObject);
	}

}
