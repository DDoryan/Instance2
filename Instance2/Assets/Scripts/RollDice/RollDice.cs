using UnityEngine;

public class RollDice : MonoBehaviour
{
    public static RollDice Instance;

    private Rigidbody _body;
    
    [SerializeField] private float _maxRandomForceValue, _rollingForce;
    private float _forceX, _forceY, _forceZ;
    private int _diceFaceNum;
    

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (_body != null)
        {
            if (Input.GetMouseButton(0))
            {
                RollDice_GetNumber();
                //Debug.Log(RollDice_GetNumber());
            }
        }
    }

    private void RollingDice()
    {
        _body.isKinematic = false;        

        _forceX = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);
        _forceY = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);
        _forceZ = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);

        _body.AddForce(Vector3.up * _rollingForce);
        _body.AddTorque(_forceX, _forceY, _forceZ);
    }

    private void Initialize()
    {
        _body = GetComponent<Rigidbody>();
        _body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    public int GetDiceFaceNum()
    {
        return _diceFaceNum;
    }

    public int SetDiceFaceNum(int diceFaceNum) 
    { 
        _diceFaceNum = diceFaceNum;
        return _diceFaceNum; 
    }

    public int RollDice_GetNumber()
    {
        RollingDice();
        return _diceFaceNum;
    }
}