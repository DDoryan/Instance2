using System.Text;
using TMPro;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public Rigidbody _body;
    private float _gravityForce = 9.8f;

    [Header("Roll Values")]
    [SerializeField] private float _maxRandomForceValue, _rollingForce;
    private float _forceX, _forceY, _forceZ;
    private int _diceFaceNum;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private string _textBeforeValue = "Dice Number : ";

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (!_body.isKinematic && _body.velocity.magnitude < 0.001f) // if the dice get stuck
        {
            RollingDice();
        }


    }

    private void FixedUpdate()
    {
        GravityCustom();
    }

    private void GravityCustom()
    {
        if (_body != null)
        {
            if (_body.isKinematic == false)
            {
                Vector3 forceGraviteVector = new Vector3(0, 0, _gravityForce);
                _body.AddForce(forceGraviteVector, ForceMode.Force);
            }
        }
    }

    public void PrintDiceFace()
    {
        _scoreText.enabled = true;
        _scoreText.text = _textBeforeValue + GetDiceFaceNum();
    }


    private void RollingDice()
    {
        _body.isKinematic = false;
        _scoreText.enabled = false;

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

    public void SetDiceFaceNum(int diceFaceNum)
    {
        _diceFaceNum = diceFaceNum;
    }


    public void SetBoolEnabledText(bool value)
    {
        _scoreText.enabled = value;
    }

    public void SetIsKinematic(bool value)
    {
        _body.isKinematic = value;
    }

    public int RollDice_GetNumber()
    {
        RollingDice();
        return _diceFaceNum;
    }
}