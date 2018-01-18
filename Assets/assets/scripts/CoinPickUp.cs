using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinPickUp : MonoBehaviour
{
	public Text point;
	private int count;

	AudioSource playerAS;

	// Use this for initialization
	void Start(){
		count = 0;
		PlayerPrefs.SetInt ("Point", 0);
		point.text = "Point: " + count.ToString ();
	}

	// Update is called once per frame
	void Update() {

	}

	public void addCoin(){
		count = count + 1;
		if (count > PlayerPrefs.GetInt ("HighPoint")) {
			PlayerPrefs.SetInt ("HighPoint", count);
		}
		PlayerPrefs.SetInt ("Point", count);
		point.text = "Point: " + count.ToString ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("coin")) {			
			addCoin();
			Destroy (other.gameObject);
			//			AudioSource.PlayClipAtPoint (healthPickupSound, transform.position, 1.0f);
		}
	}
}
