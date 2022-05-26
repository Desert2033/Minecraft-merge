using System.Collections.Generic;
using UnityEngine;

public class GeneratePersons : MonoBehaviour
{

    enum TypeAttack
    {
        Melee = 1,
        Range = 2
    }


    [SerializeField] private List<GameObject> steveRandgePrefabs;
    [SerializeField] private List<GameObject> steveMeleePrefabs;

    [SerializeField] private List<GameObject> battleFieldLinesEnemy;
    [SerializeField] private List<GameObject> battleFieldLinesFriendly;

    [SerializeField] private ArrayPersons arrayPersons;


    void Start()
    {
        //BeginGame();
        this.SpawnEnemyPerson(TypeAttack.Melee);
    }

    private void BeginGame()
    {
        this.CreatePerson(this.steveMeleePrefabs[0]);
    }

    private void SpawnFriendlyPerson()
    { 
    }

    private void SpawnEnemyPerson(TypeAttack typeAttack)
    {

        switch (typeAttack)
        {
            case TypeAttack.Melee:

                var personPrefab = CreatePerson(this.steveMeleePrefabs[0]);

                arrayPersons.SetSteveEnemy(personPrefab);

                for(var t = battleFieldLinesEnemy.Count - 1; t >= 0; t--)
                {
                    for (int i = 0; i < battleFieldLinesEnemy[t].transform.childCount; i++)
                    {
                        var cube = battleFieldLinesEnemy[t].transform.GetChild(i);
                        if (cube.childCount == 0)
                        {
                            personPrefab.transform.SetParent(cube.transform);

                            personPrefab.transform.Rotate(0, 180, 0);

                            personPrefab.transform.position = new Vector3(
                                cube.position.x, personPrefab.transform.position.y, cube.position.z);
                            return;
                        }
                    }
                }

                break;
            case TypeAttack.Range:
                break;
        }
    }

    private GameObject CreatePerson(GameObject stevePrefab)
    {
        GameObject steve = Instantiate(stevePrefab);

        return steve;
    }

}
