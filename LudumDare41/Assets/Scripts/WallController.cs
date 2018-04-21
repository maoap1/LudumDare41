using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public int lives = 1;
    private Vector3 pozice;
    public GameObject srdceint;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < lives; i++)
        {
            pozice = transform.position;
            GameObject spawnfish = (GameObject)Instantiate(srdceint, pozice, transform.rotation);
        }
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
