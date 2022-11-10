using UnityEngine;
using System;

abstract public class BasePerson : MonoBehaviour
{
    [SerializeField] private PersonData _currentLevelPerson;
    public PersonData CurrentLevelPerson => _currentLevelPerson;

    protected bool _isMove = false;

    public BasePerson CurrentEnemyTarget { set; get; }

    public event Action<BasePerson> OnDie;

    abstract public void Move();

    abstract public void TakeDamage(int damage);

    abstract public void ChangeTarget();

    public void StartMove()
    {
        _isMove = true;
    }

    public virtual void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
