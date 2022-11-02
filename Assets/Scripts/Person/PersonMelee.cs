using UnityEngine;

public class PersonMelee : BasePerson
{
    private bool _IsFight = false;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();

        phisicSteve = transform.GetComponent<Rigidbody>();

        currentHealth = CurrentLevelPerson.Health;
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            this.Die();
        }
    }

    private void FixedUpdate()
    {       
        if (!_IsFight)
        {
            //FindEnemy(); 
            //Move();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<BasePerson>(out var enemy))
        {
            if (enemy.tag != this.transform.tag)
            {
                if (currentEnemyTarget == null)
                    currentEnemyTarget = enemy;

                _IsFight = true;
                _takeDamage = _takeDamage + enemy.CurrentLevelPerson.Damage;
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsAttack", true);
            }
            Debug.Log(transform.name + " : " + currentHealth);
        }
    }

    override public void Move()
    {
        animator.SetBool("IsRunning", true);
        transform.LookAt(currentEnemyTarget.transform);
        phisicSteve.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
    }

    public void FindEnemy()
    {
        BasePerson nearEnemy = null;
/*        for (int i = 0; i < allPersonsOnBattle.GetCount(); i++)
        {
            if (allPersonsOnBattle.GetSteve(i).tag != transform.tag)
            {
                if(nearEnemy != null)
                {
                    float distanceEnemy = Vector3.Distance(allPersonsOnBattle.GetSteve(i).transform.position, this.transform.position);
                    float distanceNearEnemy = Vector3.Distance(nearEnemy.transform.position, this.transform.position);

                    if (distanceNearEnemy > distanceEnemy)
                    {
                        nearEnemy = allPersonsOnBattle.GetSteve(i).GetComponent<BasePerson>();
                    }
                }
                else
                {
                    nearEnemy = allPersonsOnBattle.GetSteve(i).GetComponent<BasePerson>();
                }
            }
        }*/

        this.currentEnemyTarget = nearEnemy;
    }
}
