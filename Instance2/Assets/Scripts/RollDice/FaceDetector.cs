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
            if (_dice.GetComponent<Rigidbody>().velocity.magnitude < 0.01f)
            {
                _dice.SetBoolIsBlocked(true);
                _dice.SetDiceFaceNum(int.Parse(other.name));
                _dice.PrintDiceFace();
            }
        }
    }
}