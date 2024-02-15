using System.Collections.Generic;
using UnityEngine;

public class TheDeath : Entity
{
    public delegate void DeathEventDelegate();
    public event DeathEventDelegate DeathEvent;
    public delegate void MoveDeathEventDelegate();
    public event MoveDeathEventDelegate MoveDeathEvent;
    [SerializeField] private UnityEngine.Transform _position;
    [SerializeField] private float _cellSize;
    [SerializeField] private int _moveNumber;
    private PlayerManager _playerManager;
    private BoardManager _boardManager;
    private int _cellOn;
    private List<Node> _opened = new List<Node>();
    private List<Node> _closed = new List<Node>();
    private List<Node> _pathToPlayerOne = new List<Node>();
    private List<Node> _pathToPlayerTwo = new List<Node>();
    private float branchWeight = 1;
    private int _baseMoveNumber;
    private Entrave _entrave;
    private Temps_Mort _tempsMort;
    public static TheDeath Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        MoveDeathEvent?.Invoke();
        _baseMoveNumber = _moveNumber;
        //_entrave.EntraveEvent += OnEntraveEvent;
        //_tempsMort.TempsMortEvent += OnTempsMortEvent;
        _playerManager = PlayerManager.Instance;
        _boardManager = BoardManager.Instance;
    }

    public override void StartRound()
    {
        base.StartRound();
        ResetMoveNumber();
        InitPath(0);
        InitPath(1);
        if (!IsEquiDist())
        {
            for (int i = 0; i < _moveNumber+1; i++)
            {
                if (_cellOn == _playerManager.GetPlayerByInd(0).GetCellOn() || _cellOn == _playerManager.GetPlayerByInd(1).GetCellOn())
                {
                    DeathEvent?.Invoke();
                }
                else
                {
                    if (_pathToPlayerOne.Count > _pathToPlayerTwo.Count)
                    {
                        _cellOn = _pathToPlayerTwo[_pathToPlayerTwo.Count - 1]._cell.GetPosInGrid();
                        _position.position = _pathToPlayerTwo[_pathToPlayerTwo.Count - 1]._cell.GetWorldPos();
                        _pathToPlayerTwo.RemoveAt(_pathToPlayerTwo.Count - 1);
                    }
                    else
                    {
                        _cellOn = _pathToPlayerOne[_pathToPlayerOne.Count - 1]._cell.GetPosInGrid();
                        _position.position = _pathToPlayerOne[_pathToPlayerOne.Count - 1]._cell.GetWorldPos();
                        _pathToPlayerOne.RemoveAt(_pathToPlayerOne.Count - 1);
                    }
                }
                if (_cellOn == _playerManager.GetPlayerByInd(0).GetCellOn() || _cellOn == _playerManager.GetPlayerByInd(1).GetCellOn())
                {
                    DeathEvent?.Invoke();
                }
            } 
        }
        MoveDeathEvent?.Invoke();
        _pathToPlayerTwo.Clear();
        _pathToPlayerOne.Clear();
        EndRound();
    }

    private bool IsEquiDist()
    {
        if (_pathToPlayerOne.Count == _pathToPlayerTwo.Count && _playerManager.GetPlayerByInd(0).transform.position != _playerManager.GetPlayerByInd(1).transform.position)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InitPath(int ind)
    {
        _opened.Clear();
        _closed.Clear();
        float heuristique = GetHeuristique(_boardManager.GetCell(_cellOn), _boardManager.GetCell(_playerManager.GetPlayerByInd(ind).GetCellOn()));
        _opened.Add(new Node(_boardManager.GetCell(_cellOn), heuristique, heuristique, null));
        
        Astar(_boardManager.GetCell(_playerManager.GetPlayerByInd(ind).GetCellOn()));
        if (ind == 0)
        {
            _pathToPlayerOne.Clear();
            GetPathFromClosedList(_closed[_closed.Count - 1], _pathToPlayerOne);
            _pathToPlayerOne.RemoveAt(_pathToPlayerOne.Count-1);
        }
        else
        {
            _pathToPlayerTwo.Clear();
            GetPathFromClosedList(_closed[_closed.Count - 1], _pathToPlayerTwo);
            _pathToPlayerTwo.RemoveAt(_pathToPlayerTwo.Count-1);
        }
    }

    private void Astar(Case finish)
    {

        int bestIndexInOpen = FindBestPotentialNodeIndex();

        Node currentNode = _opened[bestIndexInOpen];

        _opened.RemoveAt(bestIndexInOpen);

        if (currentNode._cell != finish)
        {
            foreach (Case neighbor in currentNode._cell.Neighbor)
            {
                if (ReevaluateOpen(neighbor, currentNode))
                {
                }
                else if (ReevaluateClosed(neighbor, currentNode))
                {
                }
                else
                {
                    _opened.Add(new Node(neighbor, currentNode._weight - currentNode._euristic + branchWeight + GetHeuristique(neighbor, finish), GetHeuristique(neighbor, finish), currentNode));
                }
            }
            _closed.Add(currentNode);
            Astar(finish);
        }
        else
        {
            _closed.Add(currentNode);
        }
    }

    private bool ReevaluateOpen(Case value, Node currentStudy)
    {
        for (int i = 0; i < _opened.Count; i++)
        {
            if (value == _opened[i]._cell)
            {
                if (currentStudy._weight - currentStudy._euristic + branchWeight + _opened[i]._euristic < _opened[i]._weight)
                {
                    _opened[i]._weight = currentStudy._weight - currentStudy._euristic + branchWeight + _opened[i]._euristic;
                    _opened[i]._parent = currentStudy;
                    
                }
                return true;
            }
        }
        return false;
    }

    private bool ReevaluateClosed(Case value, Node currentStudy)
    {
        for (int i = 0; i < _closed.Count; i++)
        {
            if (value == _closed[i]._cell)
            {
                if (currentStudy._weight - currentStudy._euristic + branchWeight + _closed[i]._euristic < _closed[i]._weight)
                {
                    _closed[i]._weight = currentStudy._weight - currentStudy._euristic + branchWeight + _closed[i]._euristic;
                    _closed[i]._parent = currentStudy;

                    _opened.Add(_closed[i]);
                    _closed.RemoveAt(i);
                }
                return true;
            }
        }
        return false;
    }

    private int FindBestPotentialNodeIndex()
    {
        int result = 0;
        float bestPotential = _opened[0]._weight;

        for (int i = 0; i < _opened.Count; i++)
        {
            if (_opened[i]._weight < bestPotential)
            {
                bestPotential = _opened[i]._weight;
                result = i;
            }
        }
        return result;
    }

    private float GetHeuristique(Case start, Case finish)
    {
        return Vector3.Distance(start.GetWorldPos(), finish.GetWorldPos());
    }

    private void GetPathFromClosedList(Node _node, List<Node> pathToFill)
    {
        Node value = new Node();
        value = _node;

        if (_node._parent == null)
        {
            pathToFill.Add(value);
        }
        else
        {

            pathToFill.Add(value);
            GetPathFromClosedList(value._parent, pathToFill);
        }
    }

    public void SetCellOn(int CellOn)
    {
        _cellOn = CellOn;
    }

    private void ResetMoveNumber()
    {
        if (_moveNumber != _baseMoveNumber)
        {
            _moveNumber = _baseMoveNumber;
        }
    }

    private void OnEntraveEvent()
    {
        _moveNumber -= 2;
    }

    private void OnTempsMortEvent()
    {
        _moveNumber = 0;
    }
}

public class Node
{
    public Case _cell;
    public float _weight;
    public float _euristic;
    public Node _parent;

    public Node(Case myName, float weight, float euristic, Node parent)
    {
        _cell = myName;
        _weight = weight;
        _euristic = euristic;
        _parent = parent;
    }

    public Node()
    {

    }
}
