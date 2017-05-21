using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "spaceship"){
			Spaceship s = col.gameObject.GetComponent<Spaceship>();
			s.Respawn();
		}else{
			Destroy(col.gameObject);
		}
	}
}
