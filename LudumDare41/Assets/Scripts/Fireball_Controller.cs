using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Controller : MonoBehaviour
{

    List<GameObject> ryby;
    GameObject ryba;
    public Vector3 vzdalenost;
    public float max;
    Vector3 smer;
    public int ztrata;
    

    // Use this for initialization
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (ryba == null)
            Destroy(gameObject);
        else
        {
            vzdalenost = transform.position - ryba.transform.position;
            vzdalenost.z = 0;
            smer = Vector3.Normalize(vzdalenost);

            transform.position -= 2 * smer;

            if (vzdalenost.magnitude < 1)
            {
                ryba.GetComponent<Follow>().pocet_zivotu--;

                if (ryba.GetComponent<Follow>().pocet_zivotu == 0)
                {
                    ryby.Remove(ryba);
                    Destroy(ryba);
                }
                
                Destroy(gameObject);
            }
           

        }
    }
}
