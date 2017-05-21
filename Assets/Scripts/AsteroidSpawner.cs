using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject large, med, small;

	private float spawnX, spawnY;
	private bool isSideSpawner = false;
	private List<GameObject> asteroids;


	void Start () {
		
		asteroids = new List<GameObject>();
		asteroids.Add(small);
		asteroids.Add(med);
		asteroids.Add(large);

		spawnX = transform.position.x;
		spawnY = transform.position.y;

		if(transform.position.x > 9 || transform.position.x < 1){
			isSideSpawner = true;
		}
			
	}

	void Update () {
		float chance = Random.Range(0f, 100f);
		if(chance > 99f){
			SpawnAsteroid();
		}
	}

	void SpawnAsteroid(){
		float rX = Random.Range(-5.0f,5.0f);
		int ranAst = Random.Range(0,2);
		Vector3 spawnPoint;

		if(isSideSpawner){
			spawnPoint = new Vector3(spawnX, transform.position.y + rX, 0); //spread spawns across Y plane
		}else{spawnPoint = new Vector3(transform.position.x + rX, spawnY, 0);} //spread spawns across X plane
		//random rotation to add variance
		Quaternion randZRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40f,40f)));

		Instantiate(asteroids[ranAst], spawnPoint, transform.rotation * randZRot);
	}
}
