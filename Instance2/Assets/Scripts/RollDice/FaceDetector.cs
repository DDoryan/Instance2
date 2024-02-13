using UnityEngine;
using UnityEngine.Events;

public class FaceDetector : MonoBehaviour
{
    public UnityEvent<int> _eventNumDice;

    private RollDice _dice;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent != null)
        {
            _dice = other.transform.parent.GetComponent<RollDice>();
            if (_dice != null)
            {
                if (!_dice.GetIsKinematic())
                {
                    if (_dice.GetComponent<Rigidbody>().velocity.magnitude < 0.01f)
                    {
                        _dice.SetIsKinematic(true);
                        _dice.SetDiceFaceNum(int.Parse(other.name));
                    
                        // si soucis mettre un invoke()
                    
                        _eventNumDice.Invoke(int.Parse(other.name));

                        _dice.PrintDiceFace();
                    }
                }
            }
        }
    }
}