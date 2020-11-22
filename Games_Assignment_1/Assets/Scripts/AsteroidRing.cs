using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRing : MonoBehaviour
{
    public int numOfAsteroids;
    public int radius;

    public GameObject asteroid;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfAsteroids; i++)
        {
            float angle = Mathf.PI * 2  / numOfAsteroids * i;
            float x = Mathf.Sin(angle) * radius ;
            float y = Mathf.Cos(angle) * radius;
            Vector3 pos = new Vector3(x, 0, y);
            pos = transform.TransformPoint(pos);
            for (int j = 0; j < 4; j++)
            {
                Vector3 space = new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-5f,5f));
                GameObject newAsteroid = Instantiate(asteroid, pos + space, Quaternion.identity);
                newAsteroid.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
