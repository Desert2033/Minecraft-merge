using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrayPersons : MonoBehaviour
{
    [SerializeField] private List<BasePerson> _friendlies = new List<BasePerson>();

    [SerializeField] private List<BasePerson> _enemies = new List<BasePerson>();

    public event Action<BasePerson> OnPersonDie;

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

    private void OnEnable()
    {
        if (_friendlies.Count != 0)
        {
            foreach (var item in _friendlies)
            {
                item.OnDie += RemovePerson;
            }
        }

        if (_enemies.Count != 0)
        {
            foreach (var item in _enemies)
            {
                item.OnDie += RemovePerson;
            }
        }
    }

    private void OnDisable()
    {
        MinusActions();
    }

    public bool IsFriendlyPerson(BasePerson person)
    {
        if (_friendlies.Contains(person))
        {
            return true;
        }

        return false;
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

        OnPersonDie?.Invoke(person);
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

        return null;
    }

    public BasePerson[] GetEnemies()
    {
        if (_enemies.Count != 0)
        {
            return _enemies.ToArray();
        }

        return null;
    }
}
