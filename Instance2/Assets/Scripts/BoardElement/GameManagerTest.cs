using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{

    [SerializeField]
    private int _numberOfCase;

    [SerializeField]
    private Vector3 _selectPos;

    [SerializeField]
    private int[] _id;


    private void Start()
    {
        Case _case = GameObject.FindObjectOfType<Case>();


        if (_case != null)
        {

            _case.VariableChange(1, "SelectPosWall", _selectPos);
            _case.VariableChange(1, "NumberOfCaseWall", _numberOfCase);
        }
        else
        {
            Debug.LogWarning("Instance de la classe mère non trouvée !");
        }
    }
}
