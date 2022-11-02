using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private List<BasePerson> _prefabPersons;

    [SerializeField] private CreatePerson _createPersonSystem;

    private int _layerMaskPlayerForRaycast;

    private int _layerMaskPlaneOfGridForRaycast;

    private float _cameraZDistance = 0f;

    private BasePerson _currentPersonSelect = null;

    private Selecteble _currentSelected;

    private void Start()
    {
        _layerMaskPlayerForRaycast = LayerMask.GetMask("Player");

        _layerMaskPlaneOfGridForRaycast = LayerMask.GetMask("Plane Of Grid");
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {

            if (_currentPersonSelect == null)   
            {

                Ray rayForPerson = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayForPerson, out RaycastHit hit, 100f, _layerMaskPlayerForRaycast))
                {
                    if (hit.collider.TryGetComponent(out BasePerson person))
                    {
                        _currentPersonSelect = person;
                        _cameraZDistance = 7;
                    }
                }

            }
            else
            {

                Vector3 screenMousePosition = new Vector3(
                            Input.mousePosition.x, Input.mousePosition.y, _cameraZDistance);
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);

                _currentPersonSelect.transform.position = worldMousePosition;

                Ray rayForGrid = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayForGrid, out RaycastHit hit, 100f, _layerMaskPlaneOfGridForRaycast))
                {
                    if (hit.collider.TryGetComponent(out Selecteble selecteble))
                    {
                        if (_currentSelected && _currentSelected != selecteble)
                        {
                            _currentSelected.UnSelect();
                        }

                        _currentSelected = selecteble;
                        selecteble.Select();
                    }
                }

            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentPersonSelect != null)
            {
                if (_currentSelected.transform.childCount > 0)
                {
                    if (_currentSelected.transform.GetChild(0).TryGetComponent(out BasePerson otherPerson))
                    {
                        if (otherPerson == _currentPersonSelect)
                        {
                            _currentPersonSelect.transform.position = _currentSelected.transform.position;
                        }
                        else
                        {
                            if (!this.MergePerson(_currentPersonSelect, otherPerson))
                            {
                                _currentPersonSelect.transform.position = _currentPersonSelect.transform.parent.position;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Object is without BasePerson class");
                    }
                }
                else
                {
                    _currentPersonSelect.transform.SetParent(_currentSelected.transform);
                    _currentPersonSelect.transform.position = _currentSelected.transform.position;
                }

                _currentSelected.UnSelect();
                _currentPersonSelect = null;
            }
        }
    }

    // If merge is access - true, if it not - false
    public bool MergePerson(BasePerson currentSelectPerson, BasePerson secondPerson)
    {
        int currentSelectPersonLevel = currentSelectPerson.CurrentLevelPerson.Level;
        
        string currentSelectPersonFormAttack = currentSelectPerson.CurrentLevelPerson.FormAttack;

        int secondPersonLevel = secondPerson.CurrentLevelPerson.Level;

        string secondPersonFormAttack = secondPerson.CurrentLevelPerson.FormAttack;

        if (currentSelectPersonLevel == secondPersonLevel && currentSelectPersonFormAttack == secondPersonFormAttack)
        {
            BasePerson prefabNextLevel = 
                this.GetPersonByLevelAndFormAttack(currentSelectPersonLevel + 1, currentSelectPersonFormAttack);

            Transform cell = secondPerson.transform.parent;

            currentSelectPerson.Die();

            secondPerson.Die();

            _createPersonSystem.Create(
                cell,
                prefabNextLevel.gameObject, 
                CreatePerson.LAYER_PLAYER, 
                CreatePerson.TAG_FRIENDLY);

            return true;
        }

        return false;
    }

    public BasePerson GetPersonByLevelAndFormAttack(int level, string formAttack)
    {
        for (int i = 0; i < _prefabPersons.Count; i++)
        {
            if (_prefabPersons[i].CurrentLevelPerson.Level == level && _prefabPersons[i].CurrentLevelPerson.FormAttack == formAttack) 
            {
                return _prefabPersons[i];
            }
        }

        throw new System.Exception($"Person level {level} and form attack {formAttack} is not find !!!");
    }
}
