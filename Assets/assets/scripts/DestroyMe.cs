using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float waktuHidup;

	// Use this for initialization
	void Awake () {
		Destroy (gameObject, waktuHidup);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
