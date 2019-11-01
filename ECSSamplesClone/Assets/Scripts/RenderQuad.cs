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


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    private void MakeMeshData()
    {
        vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1) };
        triangles = new int[] { 0, 1, 2, 2, 1, 3 };
    }

    private void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}

