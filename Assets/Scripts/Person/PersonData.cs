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


}
