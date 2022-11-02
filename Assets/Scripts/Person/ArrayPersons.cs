using System.Collections.Generic;
using UnityEngine;

public class ArrayPersons : MonoBehaviour
{
    [SerializeField] private List<BasePerson> _friendlies = new List<BasePerson>();

    [SerializeField] private List<BasePerson> _enemies = new List<BasePerson>();

    private void AddPerson(List<BasePerson> listAdd, BasePerson person)
    {
        listAdd.Add(person);

        person.OnDie += RemovePerson;

        listAdd.RemoveAll(item => item == null);
    }

    private void MinusActions()
    {
        if (_friendlies.Count != 0)
        {
            foreach (var item in _friendlies)
            {
                item.OnDie -= RemovePerson;
            }
        }

        if (_enemies.Count != 0)
        {
            foreach (var item in _enemies)
            {
                item.OnDie -= RemovePerson;
            }
        }
    }

    public void RemovePerson(BasePerson person)
    {
        if (_friendlies.Contains(person))
        {
            _friendlies.Remove(person);
        }

        if (_enemies.Contains(person))
        {
            _enemies.Remove(person);
        }
    }

    public void SetFriendlyPerson(BasePerson person)
    {
        this.AddPerson(_friendlies, person);
    }

    public void SetEnemyPerson(BasePerson person)
    {
        this.AddPerson(_enemies, person);
    }

    public BasePerson[] GetFriendlies()
    {
        if (_friendlies.Count != 0)
        {
            return _friendlies.ToArray();
        }

        throw new System.Exception("List 'Friendlies Person' is empty");
    }

    public BasePerson[] GetEnemies()
    {
        if (_enemies.Count != 0)
        {
            return _enemies.ToArray();
        }

        throw new System.Exception("List 'Enemies Person' is empty");
    }

    private void OnDisable()
    {
        MinusActions();
    }
}
