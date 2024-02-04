using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Path : Case
{
    

    #region SerializeField Variable
    [SerializeField]
    private int _id;



    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private GameObject _path;
    #endregion

    private Vector3 _selectPos;

    private int _numberOfCase;

    #region Getter & Setter
    public Vector3 SelectPosPath
    {
        get { return _selectPos; }
        set
        {
            _selectPos = value;
        }
    }

    public int NumberOfCasePath
    {
        get { return _numberOfCase; }
        set
        {
            _numberOfCase = value;
        }
    }

    #endregion


    //ajoute le script au dictionnaire de la class mere 
    private void Awake()
    {
        Case _case = GameObject.FindObjectOfType<Case>();

        _case.AddToDictionnary(1, this);
    }

    private void Start()
    {
        SetPath();
    }



    //permet d'instancier un certain nombre d'objet definit par la variables NumberOfCase
    private void SetPath()
    {
        if (NumberOfCasePath == 1)
        {
            _path.transform.position = SelectPosPath;
            Instantiate(_path);
            Debug.Log("Path as been Created");
        }
        else
        {
            Debug.Log("Path as been Created");
            _path.transform.position = SelectPosPath;
            for (int i = 0; i < NumberOfCasePath; i++)
            {
                Instantiate(_path);
                Vector3 PathPos = _path.transform.position;
                _path.transform.position = new Vector3(PathPos.x + _offset.x, PathPos.y + _offset.y, 0);
            }
        }
    }

    //Permet de modifier les variables dans le script en passant par la class mere (Case) 
    public override void VariableChange(int id, string variable, object valeur)
    {
        if (id == 1)
        {
            if (variable == "SelectPosPath" && valeur is Vector3)
            {
                ((Path)scripts[id]).SelectPosPath = (Vector3)valeur;
            }
            else if (variable == "NumberOfCasePath" && valeur is int)
            {
                ((Path)scripts[id]).NumberOfCasePath = (int)valeur;
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
