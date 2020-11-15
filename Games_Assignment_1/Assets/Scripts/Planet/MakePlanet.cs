using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlanet : MonoBehaviour
{
    public int resolution;
    MeshFilter[] MeshFilters = new MeshFilter[6];
    CreateMesh[] meshes = new CreateMesh[6];
    // Start is called before the first frame update
    void Start()
    {
        CreatePlanet();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlanet()
    {
        Vector3[] AllDirections = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        for (int i = 0; i < 6; i++)
        {
            {
                GameObject face =  new GameObject("Face");
                face.transform.parent = this.transform;
                
                face.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                MeshFilters[i] = face.AddComponent<MeshFilter>();
                MeshFilters[i].sharedMesh = new Mesh();
                
                meshes[i] = new CreateMesh(MeshFilters[i].sharedMesh,resolution,AllDirections[i]);
                meshes[i].Create();
            }
            
        }

    }
}
