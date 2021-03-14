using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public void SpawnObject(GameObject prefab)
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity);   
    }
}
