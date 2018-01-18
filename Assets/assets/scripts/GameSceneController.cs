using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }

    public void Paused(){
            if(canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<playerController>().enabled = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                Player.GetComponent<playerController>().enabled = true;
            }
       }
}
