using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonRay : MonoBehaviour
{

    void Start()
    {
        Vector3 parentPosition = transform.parent.position;
        Vector3 parentForward = transform.parent.forward;

        Ray ray = new Ray(parentPosition, parentForward);
    }

    void Update()
    {
        
    }
}
