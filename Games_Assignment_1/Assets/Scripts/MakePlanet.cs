using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlanet : MonoBehaviour
{
    
    public int resolution;
    public ShapeSettings settings;
    MeshFilter[] MeshFilters = new MeshFilter[6];
    CreateMesh[] meshes = new CreateMesh[6];
 
    
    [HideInInspector]
    public bool foldout;
    [HideInInspector]
    public bool autoUpdate = true;
    

    public PlanetShape shape;
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
        /*int numberOfChild = transform.childCount;
        for(int j = 0; j < numberOfChild; j++){
            Debug.Log(transform.childCount);
            DestroyImmediate(transform.GetChild(j).gameObject);
        } */
               
        shape = new PlanetShape(settings);
        Vector3[] AllDirections = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        for (int i = 0; i < 6; i++)
        {
            {
                if(MeshFilters[i] == null){
                    GameObject face =  new GameObject("Face");
                    face.transform.parent = this.transform;
                    face.transform.position = this.transform.position;
                    face.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                    MeshFilters[i] = face.AddComponent<MeshFilter>();
                    MeshFilters[i].sharedMesh = new Mesh();
                    //MeshCollider collider = face.AddComponent<MeshCollider>();
                    //collider.convex = true;
                }
                
                
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
}
