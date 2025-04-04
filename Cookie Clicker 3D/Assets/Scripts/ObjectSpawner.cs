using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab;

    public void SpawnObject(Vector3 spawnPoint)
    {
        if (objectPrefab != null)
        {
            Vector3 position = spawnPoint;
            Instantiate(objectPrefab, position, Quaternion.identity);
            Debug.Log("Object spawned: " +  position);
        }
        else
        {
            Debug.LogWarning("No prefab assigned!");
        }
    }

    public void SpawnObject(SpawningArea spawningArea){
        if (spawningArea != null && objectPrefab.GetComponent<BoxCollider>() != null)
        {
            
            Vector3 position = spawningArea.GetRandomPosition(objectPrefab);
            Instantiate(objectPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefab assigned!");
        }
    }
}
