using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpaceship : MonoBehaviour
{
    public int NumOfCircles;

    public float radius;

    public float size;
    public float speed;
    public Material material;

    private bool hasReached = false;

    private Vector3 currentPos;
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
        TargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
       
        //transform.parent.Translate(0,0,2*Time.deltaTime);
        transform.Rotate(Vector3.up);
        MoveSpaceShip(currentPos);
      
    }

    void TargetPosition()
    {
      
        Vector3 pos =  new Vector3(Random.Range(-20f,20f),Random.Range(-20f,20f),Random.Range(-20f,20f));
        pos = transform.TransformPoint(pos);
        currentPos = pos;
        Debug.Log(currentPos);
    }

    void MoveSpaceShip(Vector3 pos)
    {
        float step = speed * Time.deltaTime;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position,pos,step);
        if (Vector3.Distance(transform.parent.position, pos) < 1)
        {
            hasReached = true;
            TargetPosition();
        }
    }
}
