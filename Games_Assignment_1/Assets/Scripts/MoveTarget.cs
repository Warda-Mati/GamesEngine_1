using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTarget : MonoBehaviour
{
    public float speed;

    public RawImage target;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform targetPos = target.GetComponent<RectTransform>();
        if (Input.GetKey(KeyCode.Y))
        {
            //transform.Translate();
            targetPos.Translate(0,speed * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.H))
        {
            targetPos.Translate(0,-speed * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.G))
        {
            targetPos.Translate(speed * Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.J))
        {
            targetPos.Translate(-speed * Time.deltaTime,0,0);
        }
       
        
    }
}
