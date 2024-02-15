using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;

    void Update()
    {
        transform.localScale = new Vector3(_curve.Evaluate(Time.realtimeSinceStartup), _curve.Evaluate(Time.realtimeSinceStartup), 1);
    }
}
