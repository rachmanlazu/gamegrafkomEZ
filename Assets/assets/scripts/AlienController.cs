using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

	public GameObject flipModel;
	public GameObject ragdollDead;

	//Audio option
	public AudioClip[] diemSounds;
	public float diemSoundTime;
	AudioSource enemyMovementAS;
	float nextDiemSound = 0.0f;

	public float deteksiTime;
	float startRun;
	bool firstDeteksi;

	//movement option
	public float lariSpeed;
	public float jalanSpeed;
	public bool facingRight = true;

	float moveSpeed;
	bool lari;

	Rigidbody myRB;
	Animator myAnim;
	Transform deteksiPlayer;

	bool Deteksi;

	// Use this for initialization
	void Start () {
		myRB = GetComponentInParent<Rigidbody> ();
		myAnim = GetComponentInParent<Animator> ();
		enemyMovementAS = GetComponent<AudioSource> ();

		lari = false;
		Deteksi = false;
		firstDeteksi = false;
		moveSpeed = jalanSpeed;

		if (Random.Range (0, 10) > 5)
			Flip ();
	}

	void FixedUpdate () {
		if (Deteksi) {
			if (deteksiPlayer.position.x < transform.position.x && facingRight)
				Flip ();
			else if (deteksiPlayer.position.x > transform.position.x && !facingRight)
				Flip ();

			if (!firstDeteksi) {
				startRun = Time.time + deteksiTime;
				firstDeteksi = true;
			}
		}
		if (Deteksi && !facingRight)
			myRB.velocity = new Vector3 ((moveSpeed * -1), myRB.velocity.y, 0);
		else if (Deteksi && facingRight)
			myRB.velocity = new Vector3 (moveSpeed, myRB.velocity.y, 0);

		if (!lari && Deteksi) {
			if (startRun < Time.time) {
				moveSpeed = lariSpeed;
				myAnim.SetTrigger ("run");
				lari = true;
			}
		}

		//diem atau jalan sounds
		if (!lari) {
			if (Random.Range (0, 10) > 5 && nextDiemSound < Time.time) {
				AudioClip tempClip = diemSounds [Random.Range (0, diemSounds.Length)];
				enemyMovementAS.clip = tempClip;
				enemyMovementAS.Play ();
				nextDiemSound = diemSoundTime + Time.time;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !Deteksi) {
			Deteksi = true;
			deteksiPlayer = other.transform;
			myAnim.SetBool ("detected", Deteksi);
			if (deteksiPlayer.position.x < transform.position.x && facingRight)
				Flip ();
			else if (deteksiPlayer.position.x > transform.position.x && !facingRight)
				Flip ();
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			firstDeteksi = false;
			if (lari) {
				myAnim.SetTrigger ("run");
				moveSpeed = jalanSpeed;
				lari = false;
			}
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = flipModel.transform.localScale;
		theScale.z *= -1;
		flipModel.transform.localScale = theScale;
	}

	public void ragdollDeath(){
		GameObject ragDoll = Instantiate (ragdollDead, transform.root.transform.position, Quaternion.identity) as GameObject;

		Transform ragDolMaster = ragDoll.transform.Find ("master");
		Transform alienMaster = transform.root.Find ("master");

		bool wasFacingRight = true;
		if (!facingRight) {
			wasFacingRight = false;
			Flip ();
		}

		Transform[] ragdollJoints = ragDolMaster.GetComponentsInChildren<Transform> ();
		Transform[] currentJoints = alienMaster.GetComponentsInChildren<Transform> ();

		for (int i = 0; i < ragdollJoints.Length; i++) {
			for (int j = 0; j < currentJoints.Length; j++) {
				if (currentJoints [j].name.CompareTo (ragdollJoints [i].name) == 0) {
					ragdollJoints [i].position = currentJoints [j].position;
					ragdollJoints [i].rotation = currentJoints [j].rotation;
					break;
				}
			}
		}

		if (wasFacingRight) {
			Vector3 rotVector = new Vector3 (0, 0, 0);
			ragDoll.transform.rotation = Quaternion.Euler (rotVector);
		} else {
			Vector3 rotVector = new Vector3 (0, 90, 0);
			ragDoll.transform.rotation = Quaternion.Euler (rotVector);
		}

		Transform zombieMesh = transform.root.transform.Find ("zombieSoldier");
		Transform ragdollMesh = ragDoll.transform.Find ("zombieSoldier");

		ragdollMesh.GetComponent<Renderer> ().material = zombieMesh.GetComponent<Renderer> ().material;
	}
}
