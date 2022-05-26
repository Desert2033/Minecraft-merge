using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyPerson : BasePerson
{

    private void Start()
    {
        //this.currentLevelPerson = Resources.Load<PersonData>("ScriprableObject/Persons/Steve");
        this.phisicSteve = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
        this.currentHealth = currentLevelPerson.Health;
    }

    override public void Move()
    {
        animator.SetBool("IsRunning", true);
        phisicSteve.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
    }


}
