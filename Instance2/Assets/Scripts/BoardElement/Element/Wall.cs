using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Wall : Case
{
    #region SerializeField Variable
    [SerializeField]
    private int _id;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private GameObject _wall;
    #endregion

    private Vector3 _selectPosWall;

    private int _numberOfCaseWall;

    #region Getter & Setter
    public Vector3 SelectPosWall
    {
        get { return _selectPosWall; }
        set
        {
            _selectPosWall = value;
        }
    }

    public int NumberOfCaseWall
    {
        get { return _numberOfCaseWall; }
        set
        {
            _numberOfCaseWall = value;
        }
    }
    #endregion



    private void Awake()
    {
        Case _case = GameObject.FindObjectOfType<Case>();

        _case.AddToDictionnary(2, this);
    }

    private void Start()
    {
        SetWall();
    }


    private void SetWall()
    {
        if (NumberOfCaseWall == 1)
        {
            _wall.transform.position = SelectPosWall;
            Instantiate(_wall);
            Debug.Log("Wall as been Created");
        }
        else
        {
            _wall.transform.position = SelectPosWall;
            for (int i = 0; i < NumberOfCaseWall; i++)
            {
                Debug.Log("Wall as been Created");
                Instantiate(_wall);
                Vector3 WallPos = _wall.transform.position;
                _wall.transform.position = new Vector3(WallPos.x + _offset.x, WallPos.y + _offset.y, 0);
            }
        }
    }

    public override void VariableChange(int id, string variable, object valeur)
    {
        if (id == 2)
        {
            if (variable == "SelectPosWall" && valeur is Vector3)
            {
                ((Wall)scripts[id]).SelectPosWall = (Vector3)valeur;
            }
            else if (variable == "NumberOfCaseWall" && valeur is int)
            {
                ((Wall)scripts[id]).NumberOfCaseWall = (int)valeur;
            }
            else
            {
                Debug.LogWarning("La variable ou le type de valeur est incorrect !");
            }
        }
        else
        {
            Debug.LogWarning($"Aucun script trouvé avec l'ID {id} !");

        }
    }
}
