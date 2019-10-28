using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Entities;
using System;

public class SpawnEntities : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;

    [SerializeField]
    private int count;

    [SerializeField]
    private float radius;

    EntityManager manager;

    private void Start()
    {
        manager = World.Active.EntityManager;
    }

    Vector3 posToSpawnAt()
    {
        float x, y, z, d;
        do
        {
            x = UnityEngine.Random.Range(-radius, radius);
            y = UnityEngine.Random.Range(-radius, radius);
            z = UnityEngine.Random.Range(-radius, radius);
            d = x * x + y * y + z * z;
        } while (d > 1.0);

        return new Vector3(x, y, z);
    }

    void SpawnSphere()
    {

        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabToSpawn, World.Active);

        for (int i = 0; i < count; i++)
        {
            Entity prefabInstance = manager.Instantiate(prefab);
            manager.SetComponentData(prefabInstance, new Translation { Value = posToSpawnAt() });
            //    manager.SetComponentData(prefabInstance, new Rotation { Value = Quaternion.Euler(rotation)});
        }
    }

    private void Update()
    {
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.Translate(direction);
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnSphere();
                //SpawnGrid();
        }
    }

    private void SpawnGrid()
    {
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabToSpawn, World.Active);

        for (int x = 0; x < count; x++)
        {
            for (int y = 0; y < count; y++)
            {
                for (int z = 0; z < count; z++)
                {
                    Entity prefabInstance = manager.Instantiate(prefab);
                    manager.SetComponentData(prefabInstance, new Translation { Value = new Vector3(x, y, z) });
                }
            }
        }
    }
}
