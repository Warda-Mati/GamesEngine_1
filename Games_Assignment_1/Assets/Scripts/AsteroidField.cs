using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    public GameObject[] asteroids;
    public int numberOfAsteroids;
    public int width,height;

    private float areaOfField;
    // Start is called before the first frame update
    void Start()
    {
        areaOfField = width * height;
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-areaOfField,areaOfField),Random.Range(-areaOfField,areaOfField),Random.Range(-areaOfField,areaOfField));
            Vector3 finalPos = transform.TransformPoint(pos);
            GameObject asteroid = GameObject.Instantiate(asteroids[Random.Range(0,3)],finalPos,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
