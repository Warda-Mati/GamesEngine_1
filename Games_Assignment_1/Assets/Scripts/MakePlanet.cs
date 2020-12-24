using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlanet : MonoBehaviour
{
    
    public int resolution;
    public ShapeSettings settings;
    public PlanetColoring Coloring;
    MeshFilter[] MeshFilters = new MeshFilter[6];
    CreateMesh[] meshes = new CreateMesh[6];
 
    
    [HideInInspector]
    public bool foldout;
    [HideInInspector]
    public bool colorFoldout;
    [HideInInspector]
    public bool autoUpdate = true;

    private GameObject[] allfaces;
    public PlanetShape shape;

    public ColorGenerator generator;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlanet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlanet()
    {
        
        allfaces = new GameObject[6];
        shape = new PlanetShape(settings);
        generator = new ColorGenerator(Coloring);
        Vector3[] AllDirections = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        for (int i = 0; i < 6; i++)
        {
            {
                if(MeshFilters[i] == null){
                    GameObject face =  new GameObject("Face");
                    face.transform.parent = this.transform;
                    face.transform.position = this.transform.position;
                    face.AddComponent<MeshRenderer>().sharedMaterial = Coloring.Material ;
                    MeshFilters[i] = face.AddComponent<MeshFilter>();
                    MeshFilters[i].sharedMesh = new Mesh();
                   
                    MeshCollider collider = face.AddComponent<MeshCollider>();
                    collider.convex = true;
                    allfaces[i] = face;
                }
                generator.UpdateElevation(shape.height);
             
                meshes[i] = new CreateMesh(MeshFilters[i].sharedMesh,resolution,AllDirections[i],shape);
                meshes[i].Create();

            }
           
        }
            
        

    }
    
    public void SettingsUpdated()
    {
        if (autoUpdate)
        {
            CreatePlanet();
        }
    }

    public void ColorUpdated()
    {
        if (transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                GameObject f = transform.GetChild(0).gameObject;
                f.GetComponent<MeshRenderer>().sharedMaterial.color = Coloring.color;
            }
        }
        
       
    }
}
