﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	public Light explosionLight;
	public float power;
	public float radius;
	public float damage;

	// Use this for initialization
	void Start () {
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody> ();

			if (rb != null)
				rb.AddExplosionForce (power, explosionPos, radius, 3.0f, ForceMode.Impulse);
			if (hit.tag == "Player") {
				PlayerHealth thePlayerHealth = hit.gameObject.GetComponent<PlayerHealth> ();
				thePlayerHealth.addDamage (damage);
			} 
			else if (hit.tag == "Enemy") {
				EnemyHealth theEnemyHealth = hit.gameObject.GetComponent<EnemyHealth> ();
				theEnemyHealth.addDamage (damage);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		explosionLight.intensity = Mathf.Lerp (explosionLight.intensity, 0.0f, 5 * Time.time);
	}
}
