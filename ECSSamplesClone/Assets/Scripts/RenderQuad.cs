using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial:
//https://www.youtube.com/watch?v=v9E47DkckBE


[RequireComponent(typeof(MeshFilter))]
public class RenderQuad : MonoBehaviour
{
    private Mesh mesh;

    private Vector3[] vertices;
    int[] triangles;

    [SerializeField]
    private int gridSizeX, gridSizeY;

    private float cellSize = 1;
    private Vector3 gridOffset;//tells me how big each face is so I can make unlimited faces next to each other


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        if (gridSizeX <= 0)
            gridSizeX = 1;
        if (gridSizeY <= 0)
            gridSizeY = 1;

        MakeMeshData();
        CreateMesh();
    }

    private void MakeMeshData()
    {
        vertices = new Vector3[gridSizeX * gridSizeY * 4];
        triangles = new int[gridSizeX * gridSizeY * 6];

        float vertexOffset = cellSize * .5f;

        int v = 0;
        int t = 0;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellSize, 0, y + cellSize);

                vertices[v] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset + gridOffset;
                vertices[v+1] = new Vector3(-vertexOffset, 0, vertexOffset) + cellOffset + gridOffset;
                vertices[v + 2] = new Vector3(vertexOffset, 0, -vertexOffset) + cellOffset + gridOffset;
                vertices[v+3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset + gridOffset;


                triangles[t] = v;
                triangles[t+1] = triangles[t+4] = v+ 1;
                triangles[t+2] = triangles[t+3] = v+ 2;
                triangles[t+5] = v+ 3;

                v += 4;
                t += 6;
            }
        }
    }

    
    private void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}

