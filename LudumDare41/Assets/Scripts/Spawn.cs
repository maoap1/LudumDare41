using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject fish;

    public List<GameObject> fishes = new List<GameObject>(); 
    public int pocet_ryb = 5;
    public int jak_rychle_za_sebou = 5;
    public bool Spawning = false;
    public bool vsechny = false;

	// Update is called once per frame
	void Update () {
		if (Spawning)
        {
            Vector3 pozice = new Vector3(-750, -250, -8);
            GameObject spawnfish = (GameObject)Instantiate(fish, pozice, transform.rotation);
            fishes.Add(spawnfish);
            StartCoroutine(waiter());
            
        }

        
    }
    IEnumerator waiter()
    {
        Spawning = false;
        yield return new WaitForSeconds(jak_rychle_za_sebou);
        pocet_ryb--;
        if (pocet_ryb != 0)
        {
           Spawning = true;
        }
        else
        {
            vsechny = true;
            pocet_ryb = 5;
        }

    }
}
