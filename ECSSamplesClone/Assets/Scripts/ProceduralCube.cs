using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    [HideInInspector]
    public float scale;

    [HideInInspector]
    public Vector3 cubePos;

    private Mesh mesh;
    private List<Vector3> vertices;
    private List<int> triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        MakeCube();
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
    }


    private void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)//6 because of 6 faces to a cube
        {
            MakeFace(i);
        }
    }

    private void MakeFace(int dir)
    {
        vertices.AddRange(CubeMeshData.faceVertices(dir, scale, cubePos * scale));

        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 );
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }
}
