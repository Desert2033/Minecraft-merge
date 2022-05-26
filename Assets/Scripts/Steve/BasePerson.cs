using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BasePerson : MonoBehaviour
{

    [SerializeField] protected PersonData currentLevelPerson;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Rigidbody phisicSteve;

    protected float speed = 3;

    protected int currentHealth;

    protected bool startMove = false;

    protected List<Coroutine> takeDamageCoroutines = new List<Coroutine>();

    protected BasePerson currentEnemyTarget;

    private void FixedUpdate()
    {
        if (startMove)
            Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        BasePerson enemy = collision.gameObject.GetComponent<BasePerson>();
        if (enemy != null)
        {
            if (enemy.GetType() != this.GetType())
            {
                currentEnemyTarget = enemy;
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsAttack", true);
                startMove = false;
                takeDamageCoroutines.Add(StartCoroutine(TakeDamageEverySecond(currentLevelPerson.Damage)));
            }
            Debug.Log(transform.name + " : " + currentHealth);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        BasePerson enemy = collision.gameObject.GetComponent<BasePerson>();
        if (enemy != null)
        {
            if (enemy.GetType() != this.GetType())
            {
                takeDamageCoroutines.RemoveAt(0);
                Debug.Log("STOPPPPPP");
            }
        }
    }

    public void StartMove()
    {
        startMove = true;
    }

    abstract public void Move();

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
        gameObject.SetActive(false);
    }

    protected IEnumerator TakeDamageEverySecond(int damage)
    {
        while (true)
        {
            this.TakeDamage(damage);
            Debug.Log(transform.name + " : " + currentHealth);
            yield return new WaitForSeconds(1);
        }
    }

}
