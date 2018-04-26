using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Controller : MonoBehaviour
{

    List<GameObject> ryby;
    GameObject ryba;
    public Vector3 vzdalenost;
    public float max = 0;
    public Vector3 smer;
    public Vector3 poloha_ryby;
    public float utok = 1;
    public int dosah = 350;
    bool palba;
    public int speed;

    // Use this for initialization
    void Start()
    {
        palba = true;
        ryby = GameObject.Find("Spawner").GetComponent<Spawn>().fishes;
        for (int i = 0; i < ryby.Count; i++)
        {
            vzdalenost = transform.position - ryby[i].transform.position;
            vzdalenost.z = 0;
            if (i == 0)
            {
                max = vzdalenost.magnitude;
                ryba = ryby[0];
            }
            if (vzdalenost.magnitude < max)
            {
                max = vzdalenost.magnitude;
                ryba = ryby[i];

            }
        }
        if (max > dosah || max == 0)
        {
            palba = false;
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (palba)
        {
            if (ryba != null)
            {
                poloha_ryby = ryba.transform.position;
            }
            vzdalenost = transform.position - poloha_ryby;
            vzdalenost.z = 0;

           

            smer = Vector3.Normalize(vzdalenost);

            speed = GameObject.Find("Spawner").GetComponent<Spawn>().speed;
            transform.position -= 2 * speed * smer;
            if (utok < 1)
            {
                utok = 0.015f * speed;
            }
            if (vzdalenost.magnitude <= 2)
            {
                if (ryba != null)
                {
                    ryba.GetComponent<Follow>().pocet_zivotu -= utok;

                    if (ryba.GetComponent<Follow>().pocet_zivotu <= 0)
                    {
                        ryby.Remove(ryba);
                        Destroy(ryba);
                        
                    }
                }
                
                Destroy(gameObject);
            }


        }
    }
}
