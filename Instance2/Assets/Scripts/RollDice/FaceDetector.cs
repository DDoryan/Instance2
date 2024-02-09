using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    private RollDice _dice;

    private void Awake()
    {
        _dice = FindObjectOfType<RollDice>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (_dice != null)
        {
            if (_dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                _dice.SetDiceFaceNum(int.Parse(other.name));
            }
        }
    }
}