using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh
{
    public Mesh mesh;

    public int resolution;

    public Vector3 up, sideV, perpendicularV;

    public PlanetShape shape;

    public CreateMesh(Mesh mesh, int resolution, Vector3 up, PlanetShape shape)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.up = up;
        sideV = new Vector3(up.y,up.z,up.x);
        perpendicularV = Vector3.Cross(up, sideV);
        this.shape = shape;
    }
    public void Create()
    {
        Vector3[] vertices = new Vector3[resolution*resolution];
        int[] triangles = new int[(resolution-1)*(resolution-1)*6];

        int T = 0;
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x,y) / (resolution - 1);
                Vector3 cubePoint = up + (percent.x - .5f) * 2 * sideV + (percent.y - .5f) * 2 * perpendicularV;
                Vector3 spherePoint = cubePoint.normalized;
                vertices[i] = shape.CalculatePoint(spherePoint);

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[T] = i;
                    triangles[T + 1] = i + resolution + 1;
                    triangles[T + 2] = i + resolution;
                    
                    triangles[T + 3] = i;
                    triangles[T + 4] = i + 1;
                    triangles[T + 5] = i + resolution +1;

                    T += 6;
                    
                }
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
