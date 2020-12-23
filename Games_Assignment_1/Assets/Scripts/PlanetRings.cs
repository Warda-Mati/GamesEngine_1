using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRings : MonoBehaviour
{
    public int segments;

    public float radius, thickness;

    public Material Material;
    // Start is called before the first frame update
    void Start()
    {
        GameObject rings = new GameObject("Ring");
        rings.transform.parent = transform;
        rings.transform.localPosition = Vector3.zero;
        rings.transform.rotation = Quaternion.identity;

        MeshFilter filter = rings.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        MeshRenderer renderer = rings.AddComponent<MeshRenderer>();
        renderer.material = Material; 
        
        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2];
        int[] triangles = new int[segments * 6 * 2];
        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2];
        int halfway = (segments + 1) * 2;

        for (int i = 0; i < segments + 1; i++) {
            float progress = i / (float)segments;
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3 (x, 0f, z) * (radius + thickness);
            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3 (x, 0f, z) * radius;
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2 (progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2 (progress, 1f);

            if (i != segments) {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1 + halfway;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
            }

        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
