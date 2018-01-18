using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonjokScript : MonoBehaviour {

	public float damage;
	public float knockBack;
	public float knockBackRadius;
	public float tonjokRate;

	float nextTonjok;

	int menembakMask;

	Animator myAnim;
	playerController myPC;

	// Use this for initialization
	void Start () {
		menembakMask = LayerMask.GetMask ("Menembak");
		myAnim = transform.root.GetComponent<Animator> ();
		myPC = transform.root.GetComponent<playerController> ();
		nextTonjok = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float tonjok = Input.GetAxis ("Fire2");

		if (tonjok > 0 && nextTonjok < Time.time && !(myPC.getLari ())) {
			myAnim.SetTrigger ("senjataTonjok");
			nextTonjok = Time.time + tonjokRate;

			//damage
			Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, menembakMask);

		}
	}
}
