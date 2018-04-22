﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    public Text txt;
    public string[] str;
    public GameObject wall;
    public GameObject tower;
    public GameObject dragon;

    private Vector3 pozice;
    

    // Use this for initialization
    void Start () {
        str = txt.text.Split('\n');
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                pozice.x = (j - 7) * 100 + 50;
                pozice.y = (4 - i) * 100 - 50;
                pozice.z = 0;
                switch (str[i][j])
                {
                    case 'w':
                        GameObject nov = GameObject.Instantiate(wall, pozice, transform.rotation);
                        break;
                    case 't':
                        GameObject nova = GameObject.Instantiate(tower, pozice, transform.rotation);
                        break;
                    case 'd':
                        GameObject novy = GameObject.Instantiate(dragon, pozice, transform.rotation);
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
