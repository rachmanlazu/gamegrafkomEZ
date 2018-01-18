using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleaner : MonoBehaviour {
	public GameObject playerDeathFX;
	public Image damageScreen;
	Color flashColor = new Color(255f, 255f, 255f, 1f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			PlayerHealth playerDead = other.gameObject.GetComponent<PlayerHealth> ();
			playerDead.makeDead ();
		} else
			Destroy (gameObject);
	}

	public void makeDead(){
		Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
		damageScreen.color = flashColor;    //muncul UI bercak darah (tidak langsung hilang) saat mati
		Destroy(gameObject);
	}
}
