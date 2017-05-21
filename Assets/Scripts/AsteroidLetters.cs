using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLetters : MonoBehaviour {

	public GameObject debris;

	void OnCollisionEnter2D(){
		SpawnDebris();
		SpawnDebris();
		SpawnDebris();
		SpawnDebris();
		Destroy(gameObject);
	}

	void SpawnDebris(){
		Vector3 spawnPos = transform.position;
		Quaternion spawnRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(-360f, 360f)));
		Instantiate(debris, spawnPos, transform.rotation * spawnRot);
	}

}
