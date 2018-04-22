﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
    private const int PORTAL_IDENT = -10;

    public int lives = 1;
    public int maxlives = 1;
    private Vector3 pozice;
    public GameObject srdceint;
    public GameObject[] srdicka;

	// Use this for initialization
	void Start () {
        lives = maxlives;
        if (maxlives == PORTAL_IDENT)
        {
            return;
        }
        srdicka = new GameObject[maxlives];
        for (int i = 0; i < maxlives; i++)
        {
            pozice = transform.position;
            pozice.y += -30;
            pozice.x += - (maxlives - 1) * 10 + i * 20;
            pozice.z = -1;
                
            GameObject srdce = (GameObject)Instantiate(srdceint, pozice, transform.rotation);

            srdicka[i] = srdce;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (maxlives == PORTAL_IDENT)
        {
            if ((lives < maxlives))
            {
                PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
                playerScript.move = true;
            }
        }
        else
        {
            if (lives < maxlives)
            {
                maxlives--;
                Destroy(srdicka[maxlives]);
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
                playerScript.move = true;
            }
        }

        
        
	}



}
