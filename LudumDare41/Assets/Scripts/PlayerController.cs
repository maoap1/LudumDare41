﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    const int ID_RIGHT = 0;
    const int ID_UP = 1;
    const int ID_DOWN = 2;
    const int ID_LEFT = 3;

    private int last_direction = ID_RIGHT;
    private int previous_direction = ID_RIGHT;


    public int tileSize = 100;

    public GameObject textPro;
    private TextMeshProUGUI textmeshPro;
    public int jidlo = 10;
    public bool move = false;
    
    private Spawn spawn;
    private bool wait;
    public GameObject pointPre;
    public List<GameObject> points = new List<GameObject>();
    Vector3 pozice;
    public int pocet_ryb = 3;
    public float objevovani_ryb = 4;
    public int o_kolik_pocet = 2;
    public int o_kolik_jidlo = 2;
    public float o_kolik_objevonani = 0.5f;
    public bool mrtvy;
    GameObject portal;

    void Start ()
    {
        points.Add(pointPre);
        textmeshPro = textPro.GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText(jidlo.ToString());
        spawn = GameObject.Find("Spawner").GetComponent<Spawn>();
        portal = GameObject.Find("Portal");
	}

    void Update()
    {
        if (jidlo > 0)
        {
            wait = true;

            if (Input.GetButtonDown("Right"))
            {
                last_direction = ID_RIGHT;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<WallController>().lives--;
                    jidlo--;
                }
            }
            else if (Input.GetButtonDown("Down"))
            {
                if (previous_direction == ID_UP)
                {
                    return;
                }
                last_direction = ID_DOWN;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<WallController>().lives--;
                    jidlo--;
                }
            }
            else if (Input.GetButtonDown("Up"))
            {
                if (previous_direction == ID_DOWN)
                {
                    return;
                }
                last_direction = ID_UP;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<WallController>().lives--;
                    jidlo--;
                }
            }
            textmeshPro.SetText(jidlo.ToString());
        }
        else
        {
            
            if (wait)
            {
                spawn.pocet_ryb = pocet_ryb;
                spawn.jak_rychle_za_sebou = objevovani_ryb;
                spawn.vsechny = false;
                spawn.Spawning = true;
                wait = false;
            }
            if (spawn.fishes.Count == 0 && spawn.vsechny)
            {
                jidlo = pocet_ryb;
                pocet_ryb += o_kolik_pocet;
                spawn.zivoty += 2.5f;
                if (objevovani_ryb > o_kolik_objevonani) objevovani_ryb -= o_kolik_objevonani;
            }
        }
        
        
        if (move)
        {
            switch (last_direction)
            {
                case ID_RIGHT:
                    previous_direction = ID_RIGHT;
                    transform.Translate(Vector3.right * tileSize);
                    break;
                case ID_UP:
                    previous_direction = ID_UP;
                    transform.Translate(Vector3.up * tileSize);
                    break;
                case ID_DOWN:
                    previous_direction = ID_DOWN;
                    transform.Translate(Vector3.down * tileSize);
                    break;

            }
            pozice = transform.position;
            pozice.z = -5;
            GameObject point = (GameObject)Instantiate(pointPre, pozice, transform.rotation);
            points.Add(point);
            move = false;
        }


        if (mrtvy)
        {
            Smrt();
        }
        if (transform.position == portal.transform.position)
        {
            Vitezstvi();
        }
    }
    
   void Smrt()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void Vitezstvi()
    {
        SceneManager.LoadScene("WinningScene");
    }



}
