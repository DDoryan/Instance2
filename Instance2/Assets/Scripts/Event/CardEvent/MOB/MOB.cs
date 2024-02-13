using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : EventCard
{
    protected CameraWindowDice _cameraDice;
    protected FaceDetector detector;
    protected RollDiceManager _dice;


    [SerializeField] protected short _numberOfFaces;

    [SerializeField] protected int _minNumberRequiredToWin;
    [SerializeField] protected int _damage;

    private void Awake()
    {
        _cameraDice = GameObject.FindAnyObjectByType<CameraWindowDice>();
        detector = GameObject.FindGameObjectWithTag("DiceSystem").GetComponent<FaceDetector>();
    }
    public override void DoEvent()
    {
        if (detector != null)
            detector._eventNumDice.AddListener(OnDiceStopped);

        Debug.Log("Vous avez piochez la carte " + GetType().Name);

        _cameraDice.ToggleCameraWindow();
        _dice.DiceThrow(_numberOfFaces);
    }

    public virtual void OnDiceStopped(int num)
    {
        Debug.Log("NUM APRES AVOIR FINI DE TOURNER " + num);
        detector._eventNumDice.RemoveListener(OnDiceStopped);

        if (num >= _minNumberRequiredToWin)
        {
            _cameraDice.ToggleCameraWindow();
            //next turn
        }
        else
        {

        }
    }
}
