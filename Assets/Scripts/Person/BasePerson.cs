using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BasePerson : MonoBehaviour
{

    [SerializeField] protected PersonData currentLevelPerson;

    [SerializeField] protected ArrayPersons allPersonsOnBattle;

    [SerializeField] protected GameState gameState;

    protected Animator animator;

    protected Rigidbody phisicSteve;

    protected float speed = 3;

    protected int currentHealth;

    protected int _takeDamage = 0;

    protected Coroutine takeDamageCoroutines;

    protected BasePerson currentEnemyTarget;

    abstract public void Move();

    virtual public int GetDamage()
    {
        return currentLevelPerson.Damage;
    }

    virtual public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DestroySteve();
        }
    }

    virtual protected void DestroySteve()
    {
        Destroy(gameObject);
    }

    protected IEnumerator TakeDamageEverySecond()
    {
        while (true)
        {
            this.TakeDamage(_takeDamage);
            Debug.Log(transform.name + " : " + currentHealth);
            yield return new WaitForSeconds(1);
        }
    }

}
