using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] shooters = new GameObject[2];

    public GameObject bullets;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Transform target = shooters[i].transform.GetChild(0);
                GameObject bulletFired = Instantiate(bullets, target.transform.position, transform.rotation);
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                
                yield return  new WaitForSeconds(1);
                
            }

            yield return null;
        }
    }
}
