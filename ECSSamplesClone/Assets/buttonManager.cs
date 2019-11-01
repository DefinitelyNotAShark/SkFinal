using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeToManipulate;

    private ProceduralCube cubeScript;

    private void Start()
    {
        cubeScript = cubeToManipulate.GetComponent<ProceduralCube>();
    }

    public void ScaleUp()
    {
        cubeScript.scale += .1f;
    }

    public void ScaleDown()
    {
        if(cubeScript.scale >= .2f)
        cubeScript.scale -= .1f;
    }

    public void xUp()
    {
        cubeScript.cubePos.x += .5f;
    }

    public void xDown()
    {
        cubeScript.cubePos.x -= .5f;
    }

    public void yUp()
    {
        cubeScript.cubePos.y += .5f;
    }

    public void yDown()
    {
        cubeScript.cubePos.y -= .5f;
    }

    public void zUp()
    {
        cubeScript.cubePos.z += .5f;
    }

    public void zDown()
    {
        cubeScript.cubePos.z -= .5f;
    }
}
