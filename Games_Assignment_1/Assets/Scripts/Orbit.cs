using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
            newPlanet.GetComponent<Planet>().sun = gameObject;
            newPlanet.GetComponent<Planet>().orbitSpeed = Random.Range(0.05f, 1.5f);
            Vector3 pos = new Vector3(distance*(i + 1),0,0);
            newPlanet.transform.position = transform.TransformPoint(pos);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      
     
    }
}
