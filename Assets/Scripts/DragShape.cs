using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShape : MonoBehaviour {

	private Vector3 startPos;
	private bool isCorrectArea = false;
	private GameObject correctBucket;
	private bool isLocked = false;

	void Start(){
		startPos = transform.position;
	}

	void OnMouseDrag(){
		if(!isLocked){
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(point.x, point.y, transform.position.z);
		}
	}

	void OnMouseUp(){
		//if ye then do win
		if(isCorrectArea){
			isLocked = true;
		}else{//else move back to start pos
			transform.position = startPos;
		}
	}


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == this.name + "Bucket"){
			isCorrectArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name == this.name + "Bucket"){
			isCorrectArea = false;
		}
	}
}
