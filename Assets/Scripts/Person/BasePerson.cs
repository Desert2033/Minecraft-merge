using UnityEngine;
using System;

abstract public class BasePerson : MonoBehaviour
{
    [SerializeField] private PersonData _currentLevelPerson;
    public PersonData CurrentLevelPerson => _currentLevelPerson;

    protected Animator animator;

    protected Rigidbody phisicSteve;

    protected float speed = 3;

    protected int currentHealth;

    protected int _takeDamage = 0;

    protected BasePerson currentEnemyTarget;

    public event Action<BasePerson> OnDie;

    abstract public void Move();

    virtual public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public virtual void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
