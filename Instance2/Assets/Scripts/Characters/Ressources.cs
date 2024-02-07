using UnityEngine;

public class Ressources : MonoBehaviour
{
    [SerializeField] public int _actionPoints;
    [SerializeField] public int _magicPoints;
    private int _baseAP;
    private int _baseMP;
    public static Ressources Instance;

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

    private void Start()
    {
        _baseAP = _actionPoints;
        _baseMP = _magicPoints;
    }
    public void ResetActionPoints () 
    { 
        _actionPoints = _baseAP;
    }

    public bool SubstractActionPoints (int value)
    {
        if ((_actionPoints - value) < 0)
        {
            return false;
        }
        else
        {
            _actionPoints -= value;
            return true;
        }
    }

    public bool AddActionPoints(int value)
    {
        if (_actionPoints >= _baseAP)
        {
            return false;
        }
        else
        {
            _actionPoints += value;
            return true;
        }
    }

    public bool SubstractMagicPoints(int value)
    {
        if ((_magicPoints - value) < 0)
        {
            return false;
        }
        else
        {
            _magicPoints -= value;
            return true;
        }
    }

    public bool AddMagicPoints(int value)
    {
        if (_magicPoints >= _baseMP)
        {
            return false;
        }
        else
        {
            _magicPoints += value;
            return true;
        }
    }
}
