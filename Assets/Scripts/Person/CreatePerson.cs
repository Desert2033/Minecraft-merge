using UnityEngine;

public class CreatePerson : MonoBehaviour
{
    [SerializeField] private ArrayPersons _arrayPersons;

    public const string TAG_ENEMY = "Enemy Person";

    public const string TAG_FRIENDLY = "Friendly Person";

    private static int _layerPlayer;

    public static int LAYER_PLAYER => _layerPlayer;

    private void Awake()
    {
        _layerPlayer = LayerMask.NameToLayer("Player");
    }

    public void Create(Transform parentTransform, GameObject prefab, int layerMask, string tag)
    {
        GameObject newPerson = Instantiate(prefab);
            
        newPerson.transform.SetParent(parentTransform);
            
        newPerson.transform.position = parentTransform.position;

        newPerson.layer = layerMask;

        newPerson.tag = tag;

        if (TAG_ENEMY == tag)
        {
            _arrayPersons.SetEnemyPerson(newPerson.GetComponent<BasePerson>());
        }
        else if(TAG_FRIENDLY == tag)
        {
            _arrayPersons.SetFriendlyPerson(newPerson.GetComponent<BasePerson>());
        }
    }
}
