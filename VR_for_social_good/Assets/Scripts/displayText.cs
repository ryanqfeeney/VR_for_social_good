using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class displayText : MonoBehaviour {
	 public string message1;
	public GameObject seeText;
	// Use this for initialization
	void Start () {
		seeText.SetActive (false);
	}
	
	// Update is called once per frame
	void OnMouseOver(){
		seeText.SetActive (true);
	}
	void OnMouseExit(){
		seeText.SetActive (false);
	}
}
