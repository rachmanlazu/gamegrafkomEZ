using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TembakPeluru : MonoBehaviour {
	public float range = 10f;
	public float damage = 5f;

	Ray tembakRay;
	RaycastHit tembakHit;
	int menembak;
	LineRenderer senjataLine;


	// Use this for initialization
	void Awake () {
		menembak = LayerMask.GetMask ("Menembak");
		senjataLine = GetComponent<LineRenderer> ();

		tembakRay.origin = transform.position;
		tembakRay.direction = transform.forward;
		senjataLine.SetPosition (0, transform.position);

		if (Physics.Raycast (tembakRay, out tembakHit, range, menembak)) {
			if (tembakHit.collider.tag == "Enemy") {
				EnemyHealth theEnemyHealth = tembakHit.collider.GetComponent<EnemyHealth> ();
				if (theEnemyHealth != null) {
					theEnemyHealth.addDamage (damage);
					theEnemyHealth.damageFX (tembakHit.point, -tembakRay.direction);
				}
			}

			//tembak musuh
			senjataLine.SetPosition (1, tembakHit.point);
		} else
			senjataLine.SetPosition (1, tembakRay.origin + tembakRay.direction * range);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
