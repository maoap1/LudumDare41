using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Controller : MonoBehaviour {

    public int dostrel;
    private Spawn spawn;
    private List<GameObject> ryby;
    public Vector3 vzdalenost;
    public GameObject strelaint;
    public Vector3 pozice;

	// Use this for initialization
	void Start () {
        spawn = GameObject.Find("Spawner").AddComponent<Spawn>();
        ryby = spawn.fishes;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < ryby.Count; i++)
        {
            pozice = transform.position;
            pozice.y -= 20;
            vzdalenost = transform.position - ryby[i].transform.position;
            vzdalenost.z = 0;
            if (vzdalenost.magnitude < dostrel)
            {
                GameObject strela = (GameObject)Instantiate(strelaint, transform.position, transform.rotation);
                
            }
        }
	}

}
