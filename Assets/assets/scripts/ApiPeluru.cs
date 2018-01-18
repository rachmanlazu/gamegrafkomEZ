using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApiPeluru : MonoBehaviour {

	public float waktuTiapPeluru = 0.15f;
	public GameObject projectile;

    //info peluru
    public Slider playerAmmoSlider;
    public int maxRound;
    public int startingRound;
    int remainingRound;

	float nextPeluru;

	//info audio
	AudioSource gunMuzzleAS;
	public AudioClip shootSound;
	public AudioClip reloadSound;

	// Use this for initialization
	void Awake () {
		nextPeluru = 0f;
        remainingRound = startingRound;
        playerAmmoSlider.maxValue = maxRound;
        playerAmmoSlider.value = remainingRound;
		gunMuzzleAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerController pemain = transform.root.GetComponent<playerController> ();

		if (Input.GetAxisRaw("Fire1")>0 && nextPeluru<Time.time && remainingRound>0) {
			nextPeluru = Time.time + waktuTiapPeluru;
			Vector3 rot;
			if (pemain.GetFacing () == -1f) {
				rot = new Vector3 (0, -90, 0);
			} else
				rot = new Vector3 (0, 90, 0);

			Instantiate (projectile, transform.position, Quaternion.Euler (rot));

			playASound (shootSound);

            remainingRound -= 1;
            playerAmmoSlider.value = remainingRound;
		}
	}

	public void reload(){
		remainingRound = maxRound;
		playerAmmoSlider.value = remainingRound;
		playASound (reloadSound);
	}

	void playASound(AudioClip playTheSound){
		gunMuzzleAS.clip = playTheSound;
		gunMuzzleAS.Play ();
	}
}
