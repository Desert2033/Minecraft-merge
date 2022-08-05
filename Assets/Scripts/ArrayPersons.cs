using System.Collections.Generic;
using UnityEngine;

public class ArrayPersons : MonoBehaviour
{

   [SerializeField] private List<GameObject> steves = new List<GameObject>();


    public int GetCount()
    {
        return steves.Count;
    }

    public GameObject GetSteve(int index)
    {
        return steves[index];
    }

    public void SetSteve(GameObject value)
    {
        steves.Add(value);
    }


}
