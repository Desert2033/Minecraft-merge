using System.Collections.Generic;
using UnityEngine;

public class ArrayPersons : MonoBehaviour
{

    private List<GameObject> steveEnemies = new List<GameObject>();

    private List<GameObject> steveFriendlies = new List<GameObject>();


    public GameObject GetSteveEnemy(int index)
    {
        return steveEnemies[index];
    }

    public GameObject GetSteveFriendly(int index)
    {
        return steveFriendlies[index];
    }

    public void SetSteveEnemy(GameObject value)
    {
        steveEnemies.Add(value);
    }

    public void SetSteveFriendly(GameObject value)
    {
        steveFriendlies.Add(value);
    }

}
