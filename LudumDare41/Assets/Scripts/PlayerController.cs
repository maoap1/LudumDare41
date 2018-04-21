using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int tileSize = 100;
    public bool DEBUG = false;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    private bool press = false;
    public GameObject pointPre;
    public List<GameObject> points = new List<GameObject>();
    Vector3 pozice;

    void Start ()
    {
        points.Add(pointPre);
	}

    void Update()
    {
        myTime = myTime + Time.deltaTime;

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
            press = false;
        }
    }
    
   



}
