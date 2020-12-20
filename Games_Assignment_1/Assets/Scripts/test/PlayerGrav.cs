using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrav : MonoBehaviour
{
    // Start is called before the first frame update
    public Planet planet;
    private Transform player;
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        player = transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("planet"))
        {
            planet = other.gameObject.GetComponent<Planet>();
        }
    }

    private void FixedUpdate()
    {
        if(planet)
            planet.Attract(player);
    }
}