

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


    public int tileSize = 100;
    public bool DEBUG = false;

    public Text text;
    public int jidlo = 10;
    public bool move = false;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

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
        myTime = myTime + Time.deltaTime;

        if (jidlo > 0)
        {
            wait = true;

            if (Input.GetButtonDown("Right"))// && myTime > nextFire)
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right);
                hit.collider.gameObject.GetComponent<WallController>().lives--;
                //GameObject probe = GameObject.Find("Probe");
                //probe.transform.Translate(Vector3.right * tileSize);

                nextFire = myTime + fireDelta;
                //transform.Translate(Vector3.right * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                //press = true;
            }
            else if (Input.GetButtonDown("Down"))// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.down * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                //press = true;
            }
            else if (Input.GetButtonDown("Up"))// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.up * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                //press = true;
            }

            else if (Input.GetButtonDown("Left") && DEBUG)// && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                transform.Translate(Vector3.left * tileSize);
                nextFire = nextFire - myTime;
                myTime = 0.0F;
                //press = true;
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
            pozice = transform.position;
            pozice.z = -5;
            GameObject point = (GameObject)Instantiate(pointPre, pozice, transform.rotation);
            points.Add(point);
            move = false;
        }
    }
    
   



}
