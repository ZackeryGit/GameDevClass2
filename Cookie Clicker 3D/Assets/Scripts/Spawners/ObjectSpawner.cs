using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    private List<GameObject> objects = new List<GameObject>();
    public int maxObjects = 20;

    public void SpawnObject(Vector3 spawnPoint)
    {
        if (objectPrefab == null)
        {
            Debug.LogWarning("No prefab assigned!");
            return;
        }

        GameObject gameObject = GetPooledObject(spawnPoint);
        Debug.Log("Object spawned: " + spawnPoint);
    }

    public void SpawnObject(SpawningArea spawningArea)
    {
        if (spawningArea == null || objectPrefab == null || objectPrefab.GetComponent<BoxCollider>() == null)
        {
            Debug.LogWarning("Missing required components or prefab!");
            return;
        }

        Vector3 position = spawningArea.GetRandomPosition(objectPrefab);
        GetPooledObject(position);
    }

    private GameObject GetPooledObject(Vector3 position)
    {
        // Try to find an inactive object to reuse
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = objectPrefab.transform.rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // If under max, create new
        if (objects.Count < maxObjects)
        {
            GameObject newObj = Instantiate(objectPrefab, position, objectPrefab.transform.rotation);
            objects.Add(newObj);
            return newObj;
        }
        else
        {
            Debug.Log("Max object count reached, cannot spawn more.");
            return null;
        }
    }
}