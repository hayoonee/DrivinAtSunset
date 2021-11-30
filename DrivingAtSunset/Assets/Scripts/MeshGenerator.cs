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

    public int xSize = 20;
    public int zSize = 20;


    // Start is called before the first frame update
    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

       CreateShape();
       UpdateMesh();
    }

    private void Update()
    {
       //CreateShape();
    }

    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) *(zSize +1)];
        float randVal = Random.Range(0.1f, 0.3f);
        //Debug.Log("Random Value is: " + randVal);
        //left to right
        for (int i = 0, z = 0; z <= zSize ; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * randVal, z * randVal) * 2.0f;
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
        _mesh.Clear();
        _mesh.vertices = vertices;
        _mesh.triangles = triangles;

        _mesh.RecalculateNormals();
    }
}
