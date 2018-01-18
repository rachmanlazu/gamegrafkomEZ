using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	[SerializeField]
	float timebetweenspawn = 5f;

	[SerializeField]
	GameObject[] prefabs;

	BoxCollider collider;
	Bounds spawnbounds;
	float currenttimer = 0f;
	bool ok;

	// Use this for initialization
	void Start () {
		ok = true;
		collider = GetComponent<BoxCollider> ();

		if (collider == null) {
			Debug.LogError ("no box");
			ok = false;
		} else {
			spawnbounds = collider.bounds;
		}

		if (prefabs == null || prefabs.Length == 0) {
			Debug.LogError ("no prefabs");
			ok = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (ok) {
			currenttimer += Time.deltaTime;

			if (currenttimer >= timebetweenspawn) {
				currenttimer = 0;

				float spawnX = Random.Range (37, 55);
				float spawnY = transform.position.y;
				float spawnZ = transform.position.z;

				GameObject newItem = Object.Instantiate (GetPrefab ()) as GameObject;
				newItem.transform.position = new Vector3 (spawnX, spawnY, spawnZ);
			}
		}
	}

	private GameObject GetPrefab()
	{
		int index = Random.Range (0, prefabs.Length);

		return prefabs [index];
	}
}
