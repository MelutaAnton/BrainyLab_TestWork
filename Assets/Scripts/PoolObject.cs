using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private List<GameObject> pooledObjects;

    [SerializeField]
    private GameObject prefabObject;

    private void Awake()
    {
        pooledObjects = new List<GameObject>();
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        GameObject obj = Instantiate(prefabObject, Vector3.zero, Quaternion.identity);
        pooledObjects.Add(obj);
        return obj;
    }

    public void ClearAllLists()
    {
        foreach (GameObject obj in pooledObjects)
        {
            obj.SetActive(false);
        }
    }
}
