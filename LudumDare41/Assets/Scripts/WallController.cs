using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public int lives = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0)
        {
            Destroy(gameObject);
            PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
            playerScript.move = true;
        }
	}



}
