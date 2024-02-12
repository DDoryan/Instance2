using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    private RollDice _dice;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent != null)
        {
            _dice = other.transform.parent.GetComponent<RollDice>();
            if (_dice != null)
            {
                if (_dice.GetComponent<Rigidbody>().velocity.magnitude < 0.01f)
                {
                    _dice.SetIsKinematic(true);
                    _dice.SetDiceFaceNum(int.Parse(other.name));
                    // si soucis mettre un invoke()
                    _dice.PrintDiceFace();
                }
            }
        }
    }
}