using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CrosswordController : MonoBehaviour {

	public GameObject cellbutton;

	private int cellRowMax = 11;
	private int cellColMax = 17;
	private int cellSize = 35;
	private List<CWWord> acrossWords = new List<CWWord>();
	private List<CWWord> downWords = new List<CWWord>();
	private char[,] answerKey;
	private List<GameObject>  cellList;
	private KeyCode[] alphas;
	private string keyPressed;
	 
	void Start () {

		answerKey = new char[cellColMax,cellRowMax];

		CreateWordlist();
		CreateAnswerKey();
		GenerateCrossword();
		AddPlaceholderNumbers();

		cellList = new List<GameObject>(GameObject.FindGameObjectsWithTag("CellButton"));
	}

	void Update(){
		//if a key is pressed down (not held)
		if(AlphaInput()){
			for(int i = 0; i < cellList.Count; i++){
				CellButton c = cellList[i].GetComponent<CellButton>();
				if(c.hasFocus && !c.isCorrect){
					Text t = cellList[i].GetComponentInChildren<Text>();
					t.text = keyPressed.ToString();
					return;
				}
			}
		}
	}

	private bool AlphaInput(){
		AlphaInputs alphaInputs = gameObject.GetComponent<AlphaInputs>();
		KeyCode[] alphas = alphaInputs.alphaCodes;
		foreach(KeyCode key in alphas){
			if(Input.GetKeyDown (key)){
				keyPressed = key.ToString();
				return true;
			}
		}
		return false;
	}

	void CreateWordlist(){
		CWWord across1 = new CWWord("TO", 9, 1);
		CWWord across2 = new CWWord("PRINCIPAL", 6, 4);
		CWWord across3 = new CWWord("TWO", 1, 5);
		CWWord across4 = new CWWord("EFFECT", 3, 7);
		CWWord across5 = new CWWord("DESERT", 12, 7);
		CWWord across6 = new CWWord("TOO", 9, 9);
		CWWord across7 = new CWWord("DESSERT", 6, 11);
		acrossWords.Add(across1);
		acrossWords.Add(across2);
		acrossWords.Add(across3);
		acrossWords.Add(across4);
		acrossWords.Add(across5);
		acrossWords.Add(across6);
		acrossWords.Add(across7);

		CWWord down1 = new CWWord("THAN", 9, 1);
		CWWord down2 = new CWWord("PRINCIPLE", 7, 3);
		CWWord down3 = new CWWord("LOSE", 3, 4);
		CWWord down4 = new CWWord("AFFECT", 13, 4);
		CWWord down5 = new CWWord("LOOSE", 10, 7);
		CWWord down6 = new CWWord("THEN", 17, 7);
		downWords.Add(down1);
		downWords.Add(down2);
		downWords.Add(down3);
		downWords.Add(down4);
		downWords.Add(down5);
		downWords.Add(down6);
	}

	void CreateAnswerKey(){
		//for each across word in the acrossWords List
		for(int i = 0; i < acrossWords.Count; i++){
			// add each of its letters to the answer key in the correct slots
			for(int j = 0; j < acrossWords[i].Name.Length; j++){
				//add char to answer key cell
				// add j to account for each next letter, sub 1 because 0 counts
				answerKey[(acrossWords[i].Column + j)-1, acrossWords[i].Row-1] = acrossWords[i].Name[j];
			}
		}

		//do down words as well
		for(int i = 0; i < downWords.Count; i++){
			// add each of its letters to the answer key in the correct slots
			for(int j = 0; j < downWords[i].Name.Length; j++){
				//add char to answer key cell
				// add j to account for each next letter, sub 1 because 0 counts
				answerKey[downWords[i].Column-1, (downWords[i].Row + j)-1] = downWords[i].Name[j];
			}
		}

	}

	void GenerateCrossword(){

		for(int c = 0; c < cellColMax; c++){
			for (int r = 0; r < cellRowMax; r++){
				if(answerKey[c,r] != '\0'){
					CreateCell(c,r);
				}
			}
		}
	}

	void AddPlaceholderNumbers(){
		List<int> acrossNum = new List<int> {1, 4, 6, 7, 9, 11, 12};
		List<int> downNum = new List<int> {1, 2, 3, 5, 8, 10};
		for(int i = 0; i < acrossWords.Count; i++){ //loop through the word lists
			CWWord w = acrossWords[i];
			//cell to change
			string s = "CellC" + w.Column + "R" + w.Row;
			GameObject c = GameObject.Find(s);
			Text t = c.GetComponentInChildren<Text>();
			//change text to show the placeholder number
			t.text = acrossNum[i].ToString();
		}
		//repeat for downwords list also
		for(int i = 0; i < downWords.Count; i++){ //loop through the word lists
			CWWord w = downWords[i];
			//cell to change
			string s = "CellC" + w.Column + "R" + w.Row;
			GameObject c = GameObject.Find(s);
			Text t = c.GetComponentInChildren<Text>();
			//change text to show the placeholder number
			t.text = downNum[i].ToString();
		}
	}

	void CreateCell(int column, int row){
		//create the cell then fill in its uniques
		GameObject cell = Instantiate(cellbutton, transform.position, Quaternion.identity) as GameObject;
		cell.transform.SetParent(this.transform);
		string cellName = "CellC" + (column+1) + "R" + (row+1);
		cell.name = cellName; 
		cell.tag = "CellButton";

		//specifying correct answer
		CellButton cb = cell.GetComponent<CellButton>();
		char z = answerKey[column,row];
		cb.correctChar = z;

		//resizing and placing
		cell.transform.localScale = new Vector3(1f,1f,1f);
		RectTransform rect = cell.gameObject.GetComponent<RectTransform>();
		rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, cellSize * column, rect.rect.width);
		rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, cellSize * row, rect.rect.height);

	}

	public void ChangeCellFocus(){
		for(int i = 0; i < cellList.Count; i++){
			CellButton c = cellList[i].GetComponent<CellButton>();
			if(!c.isCorrect){
				c.hasFocus = false;
			}
		}
	}


}
