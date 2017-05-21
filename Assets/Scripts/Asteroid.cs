using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public GameObject lesser;
	public GameObject debris;

	private float speed = 0.60f;


	void Update () {
		transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}
		
	public void Breakup(){
		if(lesser == null){
			Destroy(gameObject);
		}
		//instantiate 2 asteroids of the next smallest size and some debris
		SpawnLesser();
		SpawnLesser();
		SpawnDebris();
		SpawnDebris();
		Destroy(gameObject);
	}

	void SpawnLesser(){
		//Debug.Log(gameObject.name + " instantiate lessers");
		Vector3 spawnPos = transform.position;
		Quaternion spawnRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(-360f, 360f)));
		Instantiate(lesser, spawnPos, transform.rotation * spawnRot);
	}
	 
	void SpawnDebris(){
		Vector3 spawnPos = transform.position;
		Quaternion spawnRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(-360f, 360f)));
		Instantiate(debris, spawnPos, transform.rotation * spawnRot);
	}

}
