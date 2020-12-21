using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject[] planets;
    public int distance;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            GameObject newPlanet = Instantiate(planets[i]);
            Vector3 pos = new Vector3(distance*i,0,0);
            newPlanet.transform.position = transform.TransformPoint(pos);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
