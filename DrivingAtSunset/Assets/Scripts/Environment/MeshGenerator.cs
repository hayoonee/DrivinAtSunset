using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeshGenerator : MonoBehaviour
{
    Mesh _mesh;

    Vector3[] vertices;
    int[] triangles;

    //private int xSize = 100;
    //private int zSize = 400; 
    private int xSize = 200;
    private int zSize = 800;

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        CreateShape();
        InvokeRepeating("UpdateMesh", 0.0f, 0.1f);
    }


    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) *(zSize +1)];

        float randVal = Random.Range(1f, 2f);
       
        //left to right
        for (int i = 0, z = 0; z <= zSize ; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x / 2.0f * randVal, z / 2.0f * randVal);
                vertices[i] = new Vector3(x, y, z);
              

                i++;
            }
        }

        //this is one square draw then itterated over each point
        int vert = 0;
        int tris = 0;
        triangles = new int[xSize * zSize * 6];

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }  
           vert++;
            //verts only connect with the ones next to them, not to the row ahead of them as well
        }
    }

    private void UpdateMesh()
    {
        _mesh.vertices = vertices;
        _mesh.triangles = triangles;

        _mesh.RecalculateNormals();
        CreateShape();
    }
}
