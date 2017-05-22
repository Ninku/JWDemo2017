using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

	public GameObject circle, square, triangle;

	private List<GameObject> shapes;
	private float spawnX, spawnY;

	void Start () {

		shapes = new List<GameObject>();
		shapes.Add(circle);
		shapes.Add(triangle);
		shapes.Add(square);

		spawnX = transform.position.x;
		spawnY = transform.position.y;


	}
	
	// Update is called once per frame
	void Update () {
		float chance = Random.Range(0f, 100f);
		if(chance > 97f){
			SpawnShape();
		}
	}

	void SpawnShape(){
		float rX = Random.Range(-2.0f,2.0f);
		int ranShape = Random.Range(0,3);
		Vector3 spawnPoint = new Vector3(spawnX + rX, spawnY, 0); //spread spawns across X plane

		//random rotation
		Quaternion randZRot = Quaternion.Euler(new Vector3(0, 0, Random.Range(-360f,360f)));

		GameObject g = Instantiate(shapes[ranShape], spawnPoint, transform.rotation * randZRot) as GameObject;
		g.name = shapes[ranShape].name;
		g.transform.parent = gameObject.transform;
	}
}
