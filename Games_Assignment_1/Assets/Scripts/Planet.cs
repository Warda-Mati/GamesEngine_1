using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attract(Transform player)
    {
        Vector3 planetGravity = (player.position - transform.position).normalized;
        player.GetComponent<Rigidbody>().AddForce(planetGravity * gravity);
        Quaternion target = Quaternion.FromToRotation(player.up, planetGravity) * player.rotation;
        player.rotation = Quaternion.Slerp(player.rotation,target,speed * Time.deltaTime);
    }
}