using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Person", fileName = "New Person")]
public class PersonData : ScriptableObject
{

    [SerializeField]
    private int health;

    public int Health => health;

    [SerializeField]
    private int damage;

    public int Damage => damage;

    [SerializeField]
    private int level;

    public int Level => level;

    [SerializeField]
    private string formAttack;

    public string FormAttack => formAttack;

}
