using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public void SpawnObject(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0) , Quaternion.identity);   
    }
}
