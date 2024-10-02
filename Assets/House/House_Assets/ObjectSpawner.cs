using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public BoxCollider[] bathroomAreas;
    public BoxCollider[] kitchenAreas;
    public BoxCollider[] bedroomAreas;

    public GameObject[] bathroomObjectsUnique;
    public GameObject[] bathroomObjectsRepeatable;

    public GameObject[] kitchenObjectsUnique;
    public GameObject[] kitchenObjectsRepeatable;

    public GameObject[] bedroomObjectsUnique;
    public GameObject[] bedroomObjectsRepeatable;

    void Start()
    {
            StartCoroutine(SpawnObjectsWithDelay(bathroomAreas[0], bathroomObjectsRepeatable)); foreach (BoxCollider area in bathroomAreas)
        {
            SpawnUniqueObjectInArea(area, bathroomObjectsUnique);
            SpawnRepeatableObjectsInArea(area, bathroomObjectsRepeatable);
        }
            StartCoroutine(SpawnObjectsWithDelay(kitchenAreas[0], kitchenObjectsRepeatable)); foreach (BoxCollider area in kitchenAreas)
        {
            SpawnUniqueObjectInArea(area, kitchenObjectsUnique);
            SpawnRepeatableObjectsInArea(area, kitchenObjectsRepeatable);
        }
            StartCoroutine(SpawnObjectsWithDelay(bedroomAreas[0], bedroomObjectsRepeatable)); foreach (BoxCollider area in bedroomAreas) 
        {
            SpawnUniqueObjectInArea(area, bedroomObjectsUnique);
            SpawnRepeatableObjectsInArea(area, bedroomObjectsRepeatable);
        }


    }

   
    void SpawnUniqueObjectInArea(BoxCollider area, GameObject[] uniqueObjects)
    {
        if (uniqueObjects.Length > 0)
        {
            GameObject uniqueObject = uniqueObjects[Random.Range(0, uniqueObjects.Length)];
            Vector3 randomPosition = GetRandomPosition(area);
            Instantiate(uniqueObject, randomPosition, Quaternion.identity);

            
            RemoveFromArray(ref uniqueObjects, uniqueObject);
        }
    }

    
    void SpawnRepeatableObjectsInArea(BoxCollider area, GameObject[] repeatableObjects)
    {
        int numberOfRepeats = Random.Range(1, 4); // Acá puedes cambiar cuantas repeticiones quieres
        List<Vector3> usedPositions = new List<Vector3>();
        //Esta wea es pa que no explote el pc, grax chatgpt, me salvó
        for (int i = 0; i < numberOfRepeats; i++)
        {
            if (repeatableObjects.Length > 0)
            {
                Vector3 randomPosition;
                int maxAttempts = 10;  
                int attempts = 0;

                do
                {
                    randomPosition = GetRandomPosition(area);
                    attempts++;

                    
                    if (attempts >= maxAttempts)
                    {
                        Debug.LogWarning("No se pudo encontrar una posición válida después de varios intentos.");
                        return; 
                    }
                }
                while (IsPositionUsed(randomPosition, usedPositions));

                usedPositions.Add(randomPosition);

                GameObject repeatableObject = repeatableObjects[Random.Range(0, repeatableObjects.Length)];
                Instantiate(repeatableObject, randomPosition, Quaternion.identity);
            }
        }
    }

    
    Vector3 GetRandomPosition(BoxCollider area)
    {
        return new Vector3(
            Random.Range(area.bounds.min.x, area.bounds.max.x),
            area.transform.position.y,
            Random.Range(area.bounds.min.z, area.bounds.max.z)
        );
    }

    
    bool IsPositionUsed(Vector3 position, List<Vector3> usedPositions)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < 1.0f)
                return true;
        }
        return false;
    }

    
    void RemoveFromArray(ref GameObject[] array, GameObject obj)
    {
        array = System.Array.FindAll(array, element => element != obj);
    }


    IEnumerator SpawnObjectsWithDelay(BoxCollider area, GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            Vector3 randomPosition = GetRandomPosition(area);
            Instantiate(obj, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
