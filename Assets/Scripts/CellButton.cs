using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour {

	public bool hasFocus = false;
	public bool isCorrect = false;
	public char correctChar;

	private CrosswordController cc;
	private Color basicColor;
	private Color focusColor;
	private Color correctColor;



	// Use this for initialization
	void Start () {
		cc = GetComponentInParent<CrosswordController>();

		focusColor = Color.yellow;
		basicColor = Color.white;
		correctColor = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if(isCorrect){return;}
		Text t = GetComponentInChildren<Text>();
		if(correctChar.ToString() == t.text){
			GetComponent<Image>().color = correctColor;
			isCorrect = true;
			return;
		}
		if(hasFocus){
			GetComponent<Image>().color = focusColor;
		}else{GetComponent<Image>().color = basicColor;}
	}

	public void RecievedFocus(){
		hasFocus = true;
	}

	public void LostFocus(){
		hasFocus = false;
	}

	public void OnClick(){
		if(!hasFocus){
			cc.ChangeCellFocus();
			hasFocus = true;
		}

	}




}
