using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPerson : BasePerson
{
    private void Start()
    {
        this.phisicSteve = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
        this.currentHealth = currentLevelPerson.Health;
    }

    override public void Move()
    {
        animator.SetBool("IsRunning", true);
        phisicSteve.MovePosition(transform.position + Vector3.back * Time.deltaTime * speed);
    }


}
