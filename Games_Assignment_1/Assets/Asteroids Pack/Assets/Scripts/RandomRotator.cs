using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using Random = UnityEngine.Random;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            for (int i = 0; i < 3; i++)
            {
                
                GameObject asteroid = Instantiate(gameObject,transform.position,transform.rotation);
                asteroid.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                asteroid.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0.5f,1.5f),Random.Range(0.5f,1.5f),Random.Range(0.5f,1.5f));
            }

            Destroy(this.gameObject);
        }
    }
}