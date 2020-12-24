using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject aliens;

    public int area;

    public int maxAliens,alienCounter;

    public enum Spanwing
    {
        Alien,
        Star
    };

    public Spanwing Spawntype;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Spawntype);   
    }

    private void OnEnable()
    {
        if(Spawntype == Spanwing.Alien)
            StartCoroutine(MakeSpaceShip());
        if (Spawntype == Spanwing.Star)
            StartCoroutine(SpawnStars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeSpaceShip()
    {
        while (true)
        {
            if (alienCounter < maxAliens)
            {
                Vector3 pos = new Vector3(Random.Range(-area, area), Random.Range(-area, area),
                    Random.Range(-area, area));
                pos = transform.TransformPoint(pos);
                GameObject newAlien = Instantiate(aliens, pos 
                    , Quaternion.identity);
                alienCounter++;
                newAlien.transform.parent = this.transform;
                yield return new WaitForSeconds(10);
            }

            yield return new WaitForSeconds(10);

        }
    }

    IEnumerator SpawnStars()
    {
        while (true)
        {
            Vector3 pos = new Vector3(Random.Range(-area, area), Random.Range(-area, area),
                Random.Range(-area, area));
            pos = transform.TransformPoint(pos);
            GameObject newStar = Instantiate(aliens, pos 
                , Quaternion.identity);
            newStar.transform.parent = this.transform;
            yield return new WaitForSeconds(10);
        }
    }
}
