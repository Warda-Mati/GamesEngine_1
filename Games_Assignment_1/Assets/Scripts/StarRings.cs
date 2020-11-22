using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRings : MonoBehaviour
{
   
    

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Transform star = transform.GetChild(0);
        star.transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        Transform star1 = transform.GetChild(1);
        star1.transform.RotateAround(transform.position, Vector3.right, 20 * Time.deltaTime);
    
    }
}
