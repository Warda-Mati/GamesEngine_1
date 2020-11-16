using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int speed;
    public GameObject player;
    public int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        
        transform.Translate(0,0,speed*Time.deltaTime * vert);
        transform.Rotate(0, rotationSpeed*Time.deltaTime * horiz, 0);
   
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("planet"))
        {
            if (Input.GetKey(KeyCode.P))
            {
                player.transform.parent = null;
                player.SetActive(true);
                this.gameObject.SetActive(false);
            }
          
        }
    }
}
