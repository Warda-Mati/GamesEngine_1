using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Planet : MonoBehaviour
{
    public float gravity;
    public int speed;
    public float orbitSpeed;
    public GameObject sun;

    private bool landed;
    //public int size;
    // Start is called before the first frame update
    void Start()
    {
        landed = false;
        // transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        if (landed == false)
        {
            transform.RotateAround(sun.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
      
    }

    public void Attract(Transform player)
    {
        Vector3 planetGravity = (player.position - transform.position).normalized;
        player.GetComponent<Rigidbody>().AddForce(planetGravity * gravity);
        Quaternion target = Quaternion.FromToRotation(player.up, planetGravity) * player.rotation;
        player.rotation = Quaternion.Slerp(player.rotation,target,speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            landed = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            landed = false;
        }
    }
}