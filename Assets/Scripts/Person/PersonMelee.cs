using UnityEngine;

public class PersonMelee : BasePerson
{
    private bool _isFight = false;

    private float _cooldown = 0.5f;

    private Animator _animator;

    private Rigidbody _phisicSteve;

    private float _speed = 2f;

    private int _currentHealth;

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();

        _phisicSteve = transform.GetComponent<Rigidbody>();

        _currentHealth = CurrentLevelPerson.Health;
    }

    private void FixedUpdate()
    {
        if (_currentHealth <= 0)
        {
            base.Die();
        }

        if (!_isFight)
        {
            Move();
        }
        else
        {
            LookTarget();
            if (_cooldown <= 0f)
            {
                CurrentEnemyTarget.TakeDamage(CurrentLevelPerson.Damage);
                _cooldown = 1f;
            }
            else
            {
                _cooldown -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.transform.TryGetComponent<BasePerson>(out var enemy))
        {
            if (enemy == CurrentEnemyTarget)
            {
                _isFight = true;

                _animator.SetBool("IsRunning", false);

                _animator.SetBool("IsAttack", true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent<BasePerson>(out var enemy))
        {
            if (enemy == CurrentEnemyTarget)
            {
                _isFight = false;

                _animator.SetBool("IsRunning", true);

                _animator.SetBool("IsAttack", false);
            }
        }
    }

    private void LookTarget()
    {
        Vector3 relativePos = CurrentEnemyTarget.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos);

        rotation.x = 0;
        rotation.z = 0;

        transform.rotation = rotation;
    }

    public override void ChangeTarget()
    { 
        _isFight = false;

        _animator.SetBool("IsRunning", true);

        _animator.SetBool("IsAttack", false);

        _cooldown = 0.5f;
    }

    public override void Move()
    {
        if (_isMove)
        {
            if (CurrentEnemyTarget != null)
            {
                _animator.SetBool("IsRunning", true);

                this.LookTarget();

                _phisicSteve.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed);
            }
            else
            {
                _animator.SetBool("IsRunning", false);
                _animator.SetBool("IsAttack", false);
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        //Debug.Log($"{CurrentLevelPerson.name} current HP : {_currentHealth}");
    }
}
