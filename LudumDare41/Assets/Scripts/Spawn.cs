using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject fish;

    public List<GameObject> fishes = new List<GameObject>(); 

    public bool Spawning = false;

	// Update is called once per frame
	void Update () {
		if (Spawning)
        {
            Vector3 pozice = new Vector3(-650, -250, -5);
            GameObject spawnfish = (GameObject)Instantiate(fish, pozice, transform.rotation);
            fishes.Add(spawnfish);
            Spawning = false;
        }
	}
}
