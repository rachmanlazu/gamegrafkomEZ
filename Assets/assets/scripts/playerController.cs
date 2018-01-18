using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// variabel pergerakan
	public float runSpeed;
	public float walkSpeed;
	bool lari;

	Rigidbody myRb;
	Animator myAnim;

	bool facingRight;

	//lompat
	bool grounded = false;
	Collider[] groundCollisons;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float lompatTinggi;


	//inisiasi
	void Start () {
		myRb = GetComponent<Rigidbody>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//lari
		lari = false;

		//lompat
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			myAnim.SetBool ("grounded", grounded);
			myRb.AddForce(new Vector3(0,lompatTinggi,0));
		}

		groundCollisons = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
		if (groundCollisons.Length > 0)
			grounded = true;
		else
			grounded = false;

		myAnim.SetBool ("grounded", grounded);

		//jalan jalan dan lari
		float move = Input.GetAxis("Horizontal");
		myAnim.SetFloat("kecepatan", Mathf.Abs(move));

		float jalan = Input.GetAxisRaw ("Fire3");
		myAnim.SetFloat ("jalan",jalan);

		//supaya peluru nya ga goyang ketika jalan
		float perapian = Input.GetAxis ("Fire1");
		myAnim.SetFloat ("menembak", perapian);
		//end

		if ((jalan > 0 || perapian>0) && grounded) {
			myRb.velocity = new Vector3 (move * walkSpeed, myRb.velocity.y, 0);
		}
		else {
			myRb.velocity = new Vector3 (move * runSpeed, myRb.velocity.y, 0);
			if (Mathf.Abs (move) > 0)
				lari = true;
		}
		//end jalan dan lari

		if (move>0 && !facingRight)
			Flip();
		else if (move<0 && facingRight)
			Flip();
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;
	}

	public float GetFacing(){
		if (facingRight)
			return 1;
		else
			return -1;
	}

	public bool getLari(){
		return (lari);
	}

}
