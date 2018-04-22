using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    public Text txt1;
    public Text txt2;
    public Text txt0;
    public int prepinac = 0;
    public string[] str;
    public GameObject wall;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject tower;
    public GameObject dragon;

    private Vector3 pozice;
    

    // Use this for initialization
    void Start () {
        switch (prepinac)
        {
            case 0:
                str = txt0.text.Split('\n');
                break;
            case 1:
                str = txt1.text.Split('\n');
                break;
            case 2:
                str = txt2.text.Split('\n');
                break;
           ;
        }
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
                    case 'x':
                        GameObject nov2 = GameObject.Instantiate(wall2, pozice, transform.rotation);
                        break;
                    case 'y':
                        GameObject nov3 = GameObject.Instantiate(wall3, pozice, transform.rotation);
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
