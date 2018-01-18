using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAlienAppearance : MonoBehaviour {

	public Material[] alienMaterial;

	// Use this for initialization
	void Start () {
		SkinnedMeshRenderer myRenderer = GetComponent<SkinnedMeshRenderer> ();
		myRenderer.material = alienMaterial [Random.Range (0, alienMaterial.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
