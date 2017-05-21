using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;

	private float lastFired = 0f;
	private float fireSpeed = 0.75f;
	private float turnSpeed = 50f;
	private float moveSpeed = 1f;
	private Vector3 startPos;
	private Quaternion startRot;


	void Start(){
		startPos = transform.position;
		startRot = transform.rotation;
	}

	void Update(){
		if(Input.GetKey(KeyCode.Space) && (Time.time - lastFired > fireSpeed)){
			lastFired = Time.time;
			Vector3 firePos = gun.transform.position;
			Instantiate(projectile, firePos, transform.rotation);

		}

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			transform.Rotate(0, 0, Time.deltaTime * turnSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			transform.Rotate(0, 0, Time.deltaTime * turnSpeed * -1);
		}
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.Self);
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Asteroid"){
			Asteroid a = col.gameObject.GetComponent<Asteroid>();
			a.Breakup();
			Respawn();
		}
	}

	public void Respawn(){
		//Debug.Log("respawning");
		transform.position = startPos;
		transform.rotation = startRot;
	}

}
