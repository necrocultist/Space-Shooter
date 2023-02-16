using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PoolManager : SingletonMonobehaviour<PoolManager>
{
    #region Tooltip

    [Tooltip("Prefabx to add to the pool, and the number of gameobjects to be created for each.")]

    #endregion
    [SerializeField] private Pool[] poolArray = null;

    private Transform objectPoolTransform;
    private Dictionary<int, Queue<Component>> poolDictionary = new Dictionary<int, Queue<Component>>();

    private void Start()
    {
        objectPoolTransform = this.gameObject.transform;

        for (int i = 0; i < poolArray.Length; i++)
        {
            CreatePool(poolArray[i].prefab, poolArray[i].poolSize, poolArray[i].componentType);
        }
    }

    private void CreatePool(GameObject prefab, int poolSize, string componentType)
    {
        int poolKey = prefab.GetInstanceID();

        string prefabName = prefab.name;

        GameObject parentGameObject = new GameObject(prefabName + "Anchor");

        parentGameObject.transform.SetParent(objectPoolTransform);

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<Component>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject newObject = Instantiate(prefab, parentGameObject.transform);

                newObject.SetActive(false);

                poolDictionary[poolKey].Enqueue(newObject.GetComponent(Type.GetType(componentType)));
            }
        }
    }

    public Component ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolkey = prefab.GetInstanceID();

        if (poolDictionary.ContainsKey(poolkey))
        {
            Component reuseComponent = GetComponentFromPool(poolkey);

            ResetObject(position, rotation, reuseComponent, prefab);

            return reuseComponent;
        }
        else
        {
            Debug.Log("No object pool for" + prefab);
            return null;
        }
    }

    private Component GetComponentFromPool(int poolKey)
    {
        Component reuseComponent = poolDictionary[poolKey].Dequeue();
        poolDictionary[poolKey].Enqueue(reuseComponent);

        if (reuseComponent.gameObject.activeSelf == true)
        {
            reuseComponent.gameObject.SetActive(false);
        }

        return reuseComponent;
    }

    private void ResetObject(Vector3 position, Quaternion rotation, Component reuseComponent, GameObject prefab)
    {
        reuseComponent.transform.position = position;
        reuseComponent.transform.rotation = rotation;
        reuseComponent.gameObject.transform.localScale = prefab.transform.localScale;
    }

}

[System.Serializable]
public struct Pool
{
    public int poolSize;
    public GameObject prefab;
    public string componentType;
}