using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    Dictionary<Object, Queue<Object>> _pools = new Dictionary<Object, Queue<Object>>();

    public void CreatePool(Object prefab, int size)
    {
        if (_pools.ContainsKey(prefab))
            return;

        Transform root = new GameObject($"Pool_{prefab.name}").transform;
        Queue<Object> pool = new Queue<Object>();

        for (int i = 0; i < size; i++)
        {
            Object obj = Instantiate(prefab);
            SetActive(obj, false);
            pool.Enqueue(obj);

            (obj as GameObject).transform.SetParent(root.transform);
        }

        _pools.Add(prefab, pool);
    }

    public T GetInstance<T>(T prefab) where T : Object
    {
        Queue<Object> pool;
        T obj;

        if (_pools.TryGetValue(prefab, out pool))
        {
            if(pool.Count > 0)
            {
                obj = pool.Dequeue() as T;
            }
            else
            {
                obj = Instantiate(prefab);
            }
            SetActive(obj, true);
            pool.Enqueue(obj);

            return obj;
        }

        Debug.Log("No pool was init with this prefab.");

        return null;
    }

    public void SetActive(Object obj, bool active)
    {
        GameObject go = null;

        if (obj is Component component)
            go = component.gameObject;
        else
            go = obj as GameObject;

        go.SetActive(active);
    }
}