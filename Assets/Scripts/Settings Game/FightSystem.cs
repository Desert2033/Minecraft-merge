using UnityEngine;

public class FightSystem : MonoBehaviour
{
    [SerializeField] private ArrayPersons _arrayPersons;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

 /*   public void FindEnemy()
    {
        BasePerson nearEnemy = null;
        for (int i = 0; i < allPersonsOnBattle.GetCount(); i++)
        {
            if (allPersonsOnBattle.GetSteve(i).tag != transform.tag)
            {
                if (nearEnemy != null)
                {
                    float distanceEnemy = Vector3.Distance(allPersonsOnBattle.GetSteve(i).transform.position, this.transform.position);
                    float distanceNearEnemy = Vector3.Distance(nearEnemy.transform.position, this.transform.position);

                    if (distanceNearEnemy > distanceEnemy)
                    {
                        nearEnemy = allPersonsOnBattle.GetSteve(i).GetComponent<BasePerson>();
                    }
                }
                else
                {
                    nearEnemy = allPersonsOnBattle.GetSteve(i).GetComponent<BasePerson>();
                }
            }
        }

        this.currentEnemyTarget = nearEnemy;
    }
*/
}
