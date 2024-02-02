using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

class Path : Case
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
    public Vector3 SelectPos
    {
        get { return _selectPos; }
        set
        {
            _selectPos = value;
        }
    }

    public int NumberOfCase
    {
        get { return _numberOfCase; }
        set
        {
            _numberOfCase = value;
        }
    }

    #endregion



    private void Start()
    {
        AddToList(_id, this);
        SetPath();
    }

    private void SetPath()
    {
        if (NumberOfCase == 1)
        {
            _path.transform.position = SelectPos;
            Instantiate(_path);
        }
        else
        {
            _path.transform.position = SelectPos;
            for (int i = 0; i < NumberOfCase; i++)
            {
                Instantiate(_path);
                Vector3 PathPos = _path.transform.position;
                _path.transform.position = new Vector3(PathPos.x + _offset.x, PathPos.y + _offset.y, 0);
            }
        }
    }

}
