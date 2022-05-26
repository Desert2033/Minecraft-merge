using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> where T : MonoBehaviour
{

    private List<T> pool;

    public List<T> prefabs { get; }

    public Transform container { get; }

    public PoolObjects(List<T> prefabs)
    {
        this.prefabs = prefabs;
        this.container = null;

        this.CreatePool();
    }

    public PoolObjects(List<T> prefabs, Transform container)
    {
        this.prefabs = prefabs;
        this.container = container;

        this.CreatePool();
    }

    private void CreatePool()
    {
        this.pool = new List<T>();

        foreach(var item in this.prefabs)
        {
            this.CreateObject(item);
        }
    }

    private T CreateObject(T prefab, bool isActiveByDefault = false)
    {
        var createdObjet = Object.Instantiate(prefab, this.container);
        createdObjet.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObjet);

        return createdObjet;
    }

    public bool HasFreeElement(out T element)
    {

        foreach(var item in pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                item.gameObject.SetActive(true);
                element = item;
                return true;
            }
        }

        element = null;
        return false;

    }

    public T GetFreeElement(T prefab)
    {
        if (this.HasFreeElement(out T element))
        {
            return element;
        }
        else
        {
            return this.CreateObject(prefab, true);
        }

        throw new System.Exception($"Not have free element {typeof(T)} in the pool"); 
    }

}
