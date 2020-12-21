using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRings : MonoBehaviour
{
    public int segments;

    public float radius, thickness;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject rings = new GameObject("Planet Ring");
        rings.transform.parent = transform;
        rings.transform.position = transform.TransformPoint(transform.position);
        rings.transform.rotation = Quaternion.identity;

        MeshFilter filter = rings.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        MeshRenderer renderer = rings.AddComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
