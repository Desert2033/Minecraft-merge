using UnityEngine;

//[RequireComponent(typeof(Outline))]
public class Selecteble : MonoBehaviour
{

    private Outline _outlineOdject;

    private Renderer _rendererThis;

    private void Start()
    {

        _outlineOdject = GetComponent<Outline>();
        _rendererThis = GetComponent<Renderer>();
        this.UnSelect();

    }

    public void Select()
    {
        _rendererThis.material.color = Color.red;
    }

    public void UnSelect()
    {
        _rendererThis.material.color = Color.white;
    }

}
