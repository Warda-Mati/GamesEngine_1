using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.value == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.transform.parent = null;
                child.AddComponent<Rigidbody>();
                child.GetComponent<Rigidbody>().velocity = new Vector3(3,3,3);
                Destroy(GetComponent<ShipMovement>());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sun"))
        {
            Debug.Log("Colliding with Sun");
            healthbar.value -= 0.005f;
        }
        
    }
}
