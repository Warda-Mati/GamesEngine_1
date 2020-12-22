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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(MakeSpaceShip());
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
                GameObject newAlien = Instantiate(aliens, 
                    new Vector3(Random.Range(-area, area),Random.Range(-area, area),Random.Range(-area, area)), Quaternion.identity);
                alienCounter++;
                newAlien.transform.parent = this.transform;
                yield return new WaitForSeconds(10);
            }

            yield return new WaitForSeconds(10);

        }
    }
}
