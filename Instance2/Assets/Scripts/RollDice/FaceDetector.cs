using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                _dice.DiceFaceNum = int.Parse(other.name);
            }
        }
    }
}
