using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int speed;
    public GameObject player;
    public int rotationSpeed;

    public AudioSource shipMovement;

    private Vector3 currentPos,lastPos;

    
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

        /*currentPos = transform.position;
        if (currentPos == lastPos)
        {
            shipMovement.Stop();
        }
        else
        {
            shipMovement.Play();
        }

        lastPos = currentPos;*/


    }

    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("planet"))
        {
            if (Input.GetKey(KeyCode.P))
            {
                player.SetActive(true);
                player.transform.parent = null;
                player.transform.position = transform.position;
           
                transform.position = Vector3.zero;
                this.gameObject.SetActive(false);
            }
          
        }
    }
}
