using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDeath : Entity
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _position;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private float _cellSize;
    [SerializeField] private int _moveNumber;
    private int _cellOn;
    private int _shortestPath = 1;
    private int _currentPath = 0;
    private List<List<Case>> _pathList = new List<List<Case>>();
    private List<Case> _shortestPathList = new List<Case>();
    private int _ind = 0;
    private int _min = 255;
    private Case _courseBeginning;
    private List<Node> _opened = new List<Node>();
    private List<Node> _closed = new List<Node>();
    public static TheDeath Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _opened.Add(new Node(_boardManager.GetCell(_cellOn), GetHeuristique(_cellOn,44),null));
        }
    }

    public override void StartRound()
    {
        if (_position.position == null) { return; }
        _courseBeginning = _boardManager.GetCell(_cellOn);
        PathFinding(_boardManager.GetCell(_cellOn), direction.est);
        if (IsEquiDist())
        {
            for (int i = 0; i < _moveNumber; i++)
            {
                _cellOn = _shortestPathList[i].GetPosInGrid();
            }
        }
        base.StartRound();
    }

    public void DeathSpawn()
    {
        _position.position = _startPosition.position;
    }

    private void PathFinding(Case _currentCase, direction dir )
    {
        Case _caseToLook;
        if (_currentPath <= _shortestPath)
        {
            _pathList[_ind].Add(_currentCase);
            if (_boardManager.FindNeighbourCell(direction.est, _currentCase.GetPosInGrid()) != null)
            {
                _caseToLook = _boardManager.FindNeighbourCell(direction.est, _currentCase.GetPosInGrid());
                _currentPath++;
                PathFinding(_caseToLook, direction.est);
            }
            else if (_boardManager.FindNeighbourCell(direction.north, _currentCase.GetPosInGrid()) != null)
            {
                _caseToLook = _boardManager.FindNeighbourCell(direction.north, _currentCase.GetPosInGrid());
                _currentPath++;
                PathFinding(_caseToLook, direction.north);
            }
            else if (_boardManager.FindNeighbourCell(direction.south, _currentCase.GetPosInGrid()) != null)
            {
                _caseToLook = _boardManager.FindNeighbourCell(direction.south, _currentCase.GetPosInGrid());
                _currentPath++;
                PathFinding(_caseToLook, direction.south);
            }
            else if (_boardManager.FindNeighbourCell(direction.west, _currentCase.GetPosInGrid()) != null)
            {
                _caseToLook = _boardManager.FindNeighbourCell(direction.west, _currentCase.GetPosInGrid());
                _currentPath++;
                PathFinding(_caseToLook, direction.west);
            }
        }
        else if (_currentCase.GetPosInGrid() == _playerManager.GetPlayerByInd(0).GetCellOn() || _currentCase.GetPosInGrid() == _playerManager.GetPlayerByInd(1).GetCellOn())
        {
            _pathList[_ind].Add(_currentCase);
            _ind++;
            _currentPath = 0;
            PathFinding(_courseBeginning, direction.north);
            PathFinding(_courseBeginning, direction.south);
            PathFinding(_courseBeginning, direction.west);
        }
        else
        {
            _ind++;
            _currentPath = 0;
            PathFinding(_courseBeginning, direction.north);
            PathFinding(_courseBeginning, direction.south);
            PathFinding(_courseBeginning, direction.west);
        }
        for (int i = 0; i < _pathList.Count; i++)
        {
            if (_pathList[i].Count <= _min)
            {
                _min = _pathList[i].Count;
                _shortestPathList = _pathList[i];
            }
        }
        for (int i=0; i < _pathList.Count; i++)
        {
            if (_pathList[i].Count > _min)
            {
                for (int j = 0; j < _pathList[i].Count; j++)
                {
                    _pathList[i].Remove(_pathList[i][j]);
                }
            }
        }
    }

    private bool IsEquiDist()
    {
        for (int i =0; i < _pathList.Count; ++i)
        {
            if (_pathList[i][_pathList[i].Count - 1] != _pathList[0][_pathList[0].Count - 1])
            {
                return true;
            }
            
        }
        return false;
    }

    private List<Node> Astar(Case start, Case finish)
    {
        List<Node> _result = new List<Node>();



        return _result;
    }

    private float GetHeuristique(int start, int finish)
    {
        return Vector3.Distance(_boardManager.GetCell(start).GetWorldPos(), _boardManager.GetCell(finish).GetWorldPos());
    }
    /*private void MoveTo(Vector3 direction)
    {
        _position.position = _position.position + direction * _cellSize;
    }*/
}

public class Node
{
    public Case _cell;
    public float _weight;
    public Node _parent;

    public Node(Case myName, float weight, Node parent)
    {
        _cell = myName;
        _weight = weight;
        _parent = parent;
    }
}
