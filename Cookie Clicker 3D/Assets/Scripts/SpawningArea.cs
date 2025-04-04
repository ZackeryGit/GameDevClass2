using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningArea : MonoBehaviour
{
    public BoxCollider areaBox;       // The main area to spawn within
    public bool spawnOntop;

    public Vector3 GetRandomPosition(GameObject spawnable)
    {
        if (areaBox == null)
        {
            Debug.LogError("Area BoxCollider is not assigned!");
            return Vector3.zero;
        }

        // Get the area box size and position
        Vector3 areaSize = areaBox.bounds.size;
        Vector3 areaMin = areaBox.bounds.min;
        Vector3 areaMax = areaBox.bounds.max;

        // Default random position
        Vector3 randomPosition = new Vector3(
            Random.Range(areaMin.x, areaMax.x),
            Random.Range(areaMin.y, areaMax.y),
            Random.Range(areaMin.z, areaMax.z)
        );

        // Adjust for bounding box size
        if (spawnable != null)
        {
            Vector3 boundingSize = spawnable.transform.localScale;
            Debug.Log(boundingSize);
            // Ensure the bounding box fits inside the area
            randomPosition.x = Mathf.Clamp(randomPosition.x, areaMin.x + boundingSize.x / 2, areaMax.x - boundingSize.x / 2);
            randomPosition.y = Mathf.Clamp(randomPosition.y, areaMin.y + boundingSize.y / 2, areaMax.y - boundingSize.y / 2);
            randomPosition.z = Mathf.Clamp(randomPosition.z, areaMin.z + boundingSize.z / 2, areaMax.z - boundingSize.z / 2);

            if (spawnOntop == true){
            Debug.Log(areaMax.y + " " + boundingSize);
            randomPosition.y = areaMax.y + boundingSize.y / 2;
            }

        }

        return randomPosition;
    }
}
