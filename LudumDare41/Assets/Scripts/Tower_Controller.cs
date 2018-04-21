using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Controller : MonoBehaviour
{

    public int dostrel;
    private Spawn spawn;
    public List<GameObject> ryby;
    public Vector3 vzdalenost;
    public GameObject strelaint;
    public Vector3 pozice;
    public bool strilej = true;
    public int rychlost_strelby = 10;

    // Use this for initialization
    void Start()
    {
        strilej = true;
    }

    IEnumerator waiter()
    {
        strilej = false;
        yield return new WaitForSeconds(rychlost_strelby);
        strilej = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (strilej)
        rybolov();
    }

    void rybolov()
    {
        ryby = GameObject.Find("Spawner").GetComponent<Spawn>().fishes;

        for (int i = 0; i < ryby.Count; i++)
        {
            pozice = transform.position;
            pozice.y += 30;
            pozice.z = -9;
            vzdalenost = transform.position - ryby[i].transform.position;
            vzdalenost.z = 0;
            
                if (vzdalenost.magnitude < dostrel)
                {

                    GameObject strela = (GameObject)Instantiate(strelaint, pozice, transform.rotation);
                    StartCoroutine(waiter());
                    break;

                }
            
        } 
    }
    

}

