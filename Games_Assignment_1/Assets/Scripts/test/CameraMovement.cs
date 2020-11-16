using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed; 
    public int rotationSpeed;

    public Transform target;

    public Transform playerTarget;

    private Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.parent.gameObject.activeSelf == false)
            mainCamera = playerTarget;
        else
        {
            mainCamera = target;
        }
        transform.position= Vector3.Lerp(transform.position, mainCamera.position,speed*Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, mainCamera.rotation, rotationSpeed*Time.deltaTime);

    }
}
