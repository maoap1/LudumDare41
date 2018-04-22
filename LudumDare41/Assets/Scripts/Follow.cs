﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public int kroky = 0;
    public PlayerController playerControllerInst;
    public List<GameObject> kudy;
    public Vector3 smer = new Vector3(0, 0, 0);
    public Quaternion rotace;
    public Vector3 predchozi_smer = new Vector3(1,0,0);
    public float pocet_zivotu = 10;

    public int rychlost = 100;

    public Vector3 vzdalenost = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        kroky = 0;
        playerControllerInst = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    float o_kolik;
    

    // Update is called once per frame
    void Update () {
        
        kudy = playerControllerInst.points;

        if (kroky <= kudy.Count)
        {
            vzdalenost = transform.position - kudy[kroky].transform.position;
            vzdalenost.z = 0;
            smer = Vector3.Normalize(vzdalenost);
           
            
            transform.position -= smer;

            if (vzdalenost.magnitude < 1)
            {
                kroky++;
                
            }
        }

        if (smer.y == 1) o_kolik = 90;
        if (smer.y == -1) o_kolik = -90;
        if (smer.x == 1) o_kolik = 180;
        if (smer.x == -1) o_kolik = 0;

        Quaternion target = Quaternion.Euler(0, 180, o_kolik);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);

        
        
            

        }
    }

