﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpaceship : MonoBehaviour
{
    public int NumOfCircles;

    public float radius;

    public float size;

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumOfCircles; i++)
        {
            float angle = Mathf.PI * 2  / NumOfCircles * i;
            float x = Mathf.Sin(angle) * radius ;
            float y = Mathf.Cos(angle) * radius;
            Vector3 pos = new Vector3(x, 0, y);
            pos = transform.TransformPoint(pos);
            GameObject circles = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            circles.transform.position = pos;
            circles.transform.localScale = new Vector3(size,size,size);
            circles.transform.parent = transform;
            
            circles.GetComponent<Renderer>().material = material;
           
        }

        /*HingeJoint wheel = gameObject.AddComponent<HingeJoint>();
        wheel.connectedBody = transform.parent.GetComponent<Rigidbody>();
        wheel.axis = Vector3.up;
        wheel.anchor = Vector3.up;
        wheel.autoConfigureConnectedAnchor = true;*/

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.parent.Translate(0,0,2*Time.deltaTime);
        transform.Rotate(Vector3.up);
    }
}
