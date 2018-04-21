using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public int velikost_policka;

    public float MoveAxeHorizontal;
    public float MoveAxeVertical;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveAxeHorizontal = Input.GetAxis("Horizontal");

        if (MoveAxeHorizontal == 0)
            MoveAxeVertical = Input.GetAxis("Vertical");

        if (MoveAxeHorizontal < 0) MoveAxeHorizontal = 0;

        Vector3 pohyb = new Vector3(MoveAxeHorizontal, MoveAxeVertical, 0);

        transform.position += pohyb * velikost_policka;
    }

    
}
