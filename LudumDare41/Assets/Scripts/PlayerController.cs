

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    const int ID_RIGHT = 0;
    const int ID_UP = 1;
    const int ID_DOWN = 2;
    const int ID_LEFT = 3;

    private int last_direction = ID_RIGHT;

    public int tileSize = 100;
    public bool DEBUG = false;

    public Text text;
    public int jidlo = 10;
    public bool move = false;
    
    private Spawn spawn;
    private bool wait;
    //private bool press = false;
    public GameObject pointPre;
    public List<GameObject> points = new List<GameObject>();
    Vector3 pozice;

    void Start ()
    {
        points.Add(pointPre);
        text.text = "Food: " + jidlo.ToString();
        spawn = GameObject.Find("Spawner").GetComponent<Spawn>();
	}

    void Update()
    {
        if (jidlo > 0)
        {
            wait = true;

            if (Input.GetButtonDown("Right"))
            {
                jidlo--;
                last_direction = ID_RIGHT;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right);
                hit.collider.gameObject.GetComponent<WallController>().lives--;
            }
            else if (Input.GetButtonDown("Down"))
            {
                if (last_direction==ID_UP)
                {
                    return;
                }
                jidlo--;
                last_direction = ID_DOWN;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down);
                hit.collider.gameObject.GetComponent<WallController>().lives--;
            }
            else if (Input.GetButtonDown("Up"))
            {
                if (last_direction == ID_DOWN)
                {
                    return;
                }
                jidlo--;
                last_direction = ID_UP;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up);
                hit.collider.gameObject.GetComponent<WallController>().lives--;
            }

            else if (Input.GetButtonDown("Left") && DEBUG)
            {
                transform.Translate(Vector3.left * tileSize);
            }
        }
        else
        {
            if(wait)
            {
                spawn.Spawning = true;
                wait = false;
            }
        }
        
        
        if (move)
        {
            switch (last_direction)
            {
                case ID_RIGHT:
                    transform.Translate(Vector3.right * tileSize);
                    break;
                case ID_UP:
                    transform.Translate(Vector3.up * tileSize);
                    break;
                case ID_DOWN:
                    transform.Translate(Vector3.down * tileSize);
                    break;
            }
            pozice = transform.position;
            pozice.z = -5;
            GameObject point = (GameObject)Instantiate(pointPre, pozice, transform.rotation);
            points.Add(point);
            move = false;
        }
    }
    
   



}
