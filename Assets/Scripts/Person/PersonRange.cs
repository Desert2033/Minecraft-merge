using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonRange : BasePerson
{
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();

        phisicSteve = transform.GetComponent<Rigidbody>();

        currentHealth = CurrentLevelPerson.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Move() { }

}
