using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (transform.GetChild(0) != null)
            {
                GameObject spacepart = this.transform.GetChild(0).gameObject;
                spacepart.transform.parent = null;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.5f,0.5f,0.5f);
                Destroy(this,5);
                
            }
          
        }
    }
}
