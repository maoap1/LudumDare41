using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public Text text;
    private int jidlo = 10;

    public int tileSize = 100;
    public bool DEBUG = false;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    private bool press = false;
    public GameObject pointPre;
    public List<GameObject> points = new List<GameObject>();
    private Spawn spawn;
    private bool wait;

    Vector3 pozice;

    void Start ()
    {
        points.Add(pointPre);
        text.text = "Food: " + jidlo.ToString();
        spawn = GameObject.Find("Spawner").GetComponent<Spawn>();


    }


    void Update()
    {
        myTime = myTime + Time.deltaTime;
       
        if (jidlo > 0)
        {
            wait = true;
            if (Input.GetButtonDown("Right"))// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.right * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                press = true;
            }
            else if (Input.GetButtonDown("Down"))// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.down * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                press = true;
            }
            else if (Input.GetButtonDown("Up"))// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.up * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                press = true;
            }


            else if (Input.GetButtonDown("Left") && DEBUG)// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.left * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                press = true;
            }

            if (press)
            {
                pozice = transform.position;
                pozice.z = -5;
                GameObject point = (GameObject)Instantiate(pointPre, pozice, transform.rotation);
                points.Add(point);
                jidlo--;
                text.text = "Food: " + jidlo.ToString();
                press = false;
            }
        }
        else
        {
            if (wait)
            {
                spawn.Spawning = true;
                wait = false;
            }
           
        }

        
    }
    
   



}
