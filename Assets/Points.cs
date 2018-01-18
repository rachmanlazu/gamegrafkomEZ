using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {
	public Text Pointss;
	public Text HighPointss;

	private int scr;

	// Use this for initialization
	void Start () {
		scr = PlayerPrefs.GetInt ("Point");
		Pointss.text = "Your Score: " + scr.ToString ();
		HighPointss.text = "High Score: " + PlayerPrefs.GetInt ("HighPoint");
	}

	// Update is called once per frame
	void Update () {

	}
}
