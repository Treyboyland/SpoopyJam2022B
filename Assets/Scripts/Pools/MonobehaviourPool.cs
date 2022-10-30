using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    protected T prefab;

    protected List<T> pool = new List<T>();

    public virtual int ActiveCount
    {
        get
        {
            int count = 0;
            foreach (var obj in pool)
            {
                if (obj.gameObject.activeInHierarchy)
                {
                    count++;
                }
            }

            return count;
        }
    }

    protected T CreateObject()
    {
        var newObj = Instantiate(prefab, transform);
        pool.Add(newObj);
        return newObj;
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public virtual void SpawnObject(Vector3 pos)
    {
        var obj = GetObject();
        obj.transform.position = pos;
        obj.gameObject.SetActive(true);
    }

    public virtual void SpawnObject()
    {
        GetObject().gameObject.SetActive(true);
    }
}
