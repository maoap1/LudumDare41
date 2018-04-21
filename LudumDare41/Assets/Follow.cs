using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public int kroky = 0;
    public GameObject player;
    public PlayerController playerControllerInst;
    public List<GameObject> kudy;
    public Vector3 smer;
    public Quaternion rotace;

    public int rychlost = 100;

    public Vector3 vzdalenost;

	// Use this for initialization
	void Start () {
        kroky = 0;
    }

    

	// Update is called once per frame
	void Update () {
        playerControllerInst = GameObject.Find("Player").GetComponent<PlayerController>();
        kudy = playerControllerInst.points;

        if (kroky <= kudy.Count)
        {
            vzdalenost = transform.position - kudy[kroky].transform.position;
            vzdalenost.z = 0;
            smer = Vector3.Normalize(vzdalenost);

            rotace = transform.rotation;
            
            if (smer.y == 0)
                rotace.z = smer.x * 90;
            else if (smer.x == 0)
                rotace.z = 90 - smer.y * 90;

            transform.position -= smer;
            transform.rotation = rotace;

            if (vzdalenost.magnitude < 1)
            {
                kroky++;
            }

            
        }
     }
}
