using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Grave _grave;








   
    private void Awake()
    {
        _grave = new Grave(CaseType.Grave, false, false, 1, null, Vector2.zero, null);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _grave.Interact();
        }
    }
}
