using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonRange : BasePerson
{
    void Start()
    {
       /* animator = transform.GetChild(0).GetComponent<Animator>();

        phisicSteve = transform.GetComponent<Rigidbody>();

        currentHealth = CurrentLevelPerson.Health;*/
    }

    void Update()
    {
        
    }

    public override void Move() { }

    public override void TakeDamage(int damage)
    {
    }

    public override void ChangeTarget()
    {
        throw new System.NotImplementedException();
    }
}
