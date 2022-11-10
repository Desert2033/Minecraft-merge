using UnityEngine;

public class FightSystem : MonoBehaviour
{
    [SerializeField] private ArrayPersons _arrayPersons;

    private void OnDisable()
    {
        _arrayPersons.OnPersonDie -= OnDieTarget;
    }

    public void StartFight()
    {
        this.FindTargetForAllPersons();

        _arrayPersons.OnPersonDie += OnDieTarget;

        foreach (var enemy in _arrayPersons.GetEnemies())
        {
            enemy.StartMove();
        }

        foreach (var friendly in _arrayPersons.GetFriendlies())
        {
            friendly.StartMove();
        }
    }

    public void FindTargetForAllPersons() 
    {
        foreach (var enemy in _arrayPersons.GetEnemies())
        {
            if (enemy.CurrentEnemyTarget == null)
            {
                this.FindTarget(enemy);
            }
        }

        foreach(var friendly in _arrayPersons.GetFriendlies())
        {
            if (friendly.CurrentEnemyTarget == null)
            {
                this.FindTarget(friendly);
            }
        }
    }

    public void FindTarget(BasePerson personWithoutTarget)
    {
        BasePerson[] searchTarget;

        if (_arrayPersons.IsFriendlyPerson(personWithoutTarget))
        {
            searchTarget = _arrayPersons.GetEnemies();
        }
        else
        {
            searchTarget = _arrayPersons.GetFriendlies();
        }

        BasePerson nearTarget = null;

        if (searchTarget != null) 
        {
            foreach (var target in searchTarget)
            {
                if (nearTarget != null)
                {
                    float distanceEnemy = Vector3.Distance(target.transform.position, personWithoutTarget.transform.position);
                        
                    float distanceNearEnemy = Vector3.Distance(nearTarget.transform.position, personWithoutTarget.transform.position);

                    if (distanceNearEnemy > distanceEnemy)
                    {
                        nearTarget = target;
                    }
                }
                else
                {
                    nearTarget = target;
                }
            }
        }

        personWithoutTarget.CurrentEnemyTarget = nearTarget;
    }

    public void OnDieTarget(BasePerson targetDie)
    {
        if (_arrayPersons.GetEnemies() != null)
        {
            foreach (var enemy in _arrayPersons.GetEnemies())
            {
                if (enemy.CurrentEnemyTarget == targetDie)
                {
                    FindTarget(enemy);
                    enemy.ChangeTarget();
                }
            }
        }

        if (_arrayPersons.GetFriendlies() != null)
        {
            foreach (var frienly in _arrayPersons.GetFriendlies())
            {
                if (frienly.CurrentEnemyTarget == targetDie)
                {
                    FindTarget(frienly);
                    frienly.ChangeTarget();
                }
            }
        }
    }
}
