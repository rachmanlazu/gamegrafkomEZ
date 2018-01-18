using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;
	public float damageModifier;
	public GameObject damageParticle;
	public bool drops;
	public GameObject drop;
	public AudioClip deathSound;
	public bool kebakar;
	public float bakarDamage;
	public float BakarTime;
	public GameObject bakarEfek;

	bool onFire;
	float nextBakar;
	float bakarInterval = 1f;
	float endBakar;

	float nyawaSekarang;

	public Slider enemyHealthIndicator;

	AudioSource enemyAS;

	// Use this for initialization
	void Awake () {
		nyawaSekarang = enemyMaxHealth;
		enemyHealthIndicator.maxValue = enemyMaxHealth;
		enemyHealthIndicator.value = nyawaSekarang;
		enemyAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (onFire && Time.time > nextBakar) {
			addDamage (bakarDamage);
			nextBakar += bakarInterval;
		}
		if (onFire && Time.time > endBakar) {
			onFire = false;
			bakarEfek.SetActive (false);
		}
	}

	public void addDamage(float damage){
		enemyHealthIndicator.gameObject.SetActive (true);
		damage = damage * damageModifier;
		if (damage <= 0f)
			return;
		nyawaSekarang -= damage;
		enemyHealthIndicator.value = nyawaSekarang;
		enemyAS.Play ();
		if (nyawaSekarang <= 0)
			makeDead ();
	}

	public void damageFX(Vector3 point, Vector3 rotation){
		Instantiate(damageParticle, point, Quaternion.Euler(rotation));
	}

	public void addFire(){
		if (!kebakar)
			return;
		onFire = true;
		bakarEfek.SetActive (true);
		endBakar = Time.time + BakarTime;
		nextBakar = Time.time + bakarInterval;
	}

	void makeDead(){
		//berhenti pindah

		AudioSource.PlayClipAtPoint (deathSound, transform.position, 10.0f);

		Destroy (gameObject.transform.root.gameObject);
		if (drops) Instantiate (drop, transform.position, Quaternion.identity);
		
		AlienController aAlien = GetComponentInChildren<AlienController> ();
		if (aAlien != null) {
			aAlien.ragdollDeath ();
		}
		
	}
}
