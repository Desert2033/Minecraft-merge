using UnityEngine;
using System.Collections.Generic;

public class SpawnPerson : MonoBehaviour
{
    [SerializeField] private Transform _grid;

    [SerializeField] private CreatePerson _createPersonSystem;

    private List<Transform> _cellsTransform;

    private void Start()
    {
        _cellsTransform = new List<Transform>();

        List<Transform> linesTransform = GetChildrenFromObject(_grid);

        foreach (var line in linesTransform)
        {
            _cellsTransform.AddRange(GetChildrenFromObject(line));
        }
    }

    private List<Transform> GetChildrenFromObject(Transform objectTransform)
    {
        List<Transform> childrenTransform = new List<Transform>();

        for (int i = 0; i < objectTransform.childCount; i++)
        {
            childrenTransform.Add(objectTransform.GetChild(i));
        }

        return childrenTransform;
    }

    private bool GetFreeCell(out Transform freeCellTransform)
    {
        foreach(var cell in _cellsTransform)
        {
            if(cell.childCount == 0)
            {
                freeCellTransform = cell;
                return true;
            }
        }

        freeCellTransform = null;
        return false;
    }

    public void SpawnMeleePerson()
    {
        GameObject personPrefab = Resources.Load<GameObject>("Prefabs/Steves/Melee Steve/Steve lvl 1");

        if (GetFreeCell(out Transform freeCell))
        {
            _createPersonSystem.Create(freeCell, personPrefab, LayerMask.NameToLayer("Player"), CreatePerson.TAG_FRIENDLY);
        }
    }
    
    public void SpawnRangePerson()
    {
        /*GameObject person = Resources.Load<GameObject>("Prefabs/Steves/Melee Steve/Steve lvl 1");

        if (GetFreeCell(out Transform freeCell))
        {
            CreatePerson(freeCell, person);
        }*/
    }
}
