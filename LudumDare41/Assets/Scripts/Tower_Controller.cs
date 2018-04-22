using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Controller : MonoBehaviour
{

    public int dostrel = 200;
    public int rychlost_strelby = 10;
    private Spawn spawn;
    private List<GameObject> ryby;
    private Vector3 vzdalenost;
    public GameObject strelaint;
    private Vector3 pozice;
    private bool strilej = true;
    public int posunuti;

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
            pozice.y += posunuti;
            pozice.z = -9;
            vzdalenost = transform.position - ryby[i].transform.position;
            vzdalenost.z = 0;

            if (vzdalenost.magnitude < dostrel)
            {
                GameObject strela = (GameObject)Instantiate(strelaint, pozice, transform.rotation);
                strela.GetComponent<Fireball_Controller>().dosah = dostrel;

                if (rychlost_strelby > 0) StartCoroutine(waiter());
                break;

            }
            
        } 
    }
    

}

