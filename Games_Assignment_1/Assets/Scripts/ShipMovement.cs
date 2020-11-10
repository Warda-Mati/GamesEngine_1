using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int speed;

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
        transform.Rotate(rotationSpeed*Time.deltaTime * horiz, 0, 0);
        
        

    }
}
