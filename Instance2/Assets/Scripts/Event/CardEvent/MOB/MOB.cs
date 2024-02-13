using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : EventCard
{
    protected CameraWindowDice _cameraDice;
    protected FaceDetector detector;
    protected RollDiceManager _dice;


    protected short _numberOfFaces;

    protected int _minNumberRequiredToWin;
    protected int _damagePa;

    private PlayerManager _playerManager;

    public delegate void DiceStoppedHandler();
    public event DiceStoppedHandler OnDiceStoppedEvent;



    private void Awake()
    {
        _cameraDice = GameObject.FindAnyObjectByType<CameraWindowDice>();
        detector = GameObject.FindGameObjectWithTag("DiceSystem").GetComponent<FaceDetector>();
    }
    public override void DoEvent()
    {
        if (detector != null)
            detector.EventNumDice.AddListener(OnDiceStopped);

        Debug.Log("Vous avez piochez la carte " + GetType().Name);

        _cameraDice.ToggleCameraWindow();
        _dice.DiceThrow(_numberOfFaces);
    }

    public virtual void OnDiceStopped(int num)
    {
        Debug.Log("NUM APRES AVOIR FINI DE TOURNER " + num);

        if (num >= _minNumberRequiredToWin)
        {
            _cameraDice.ToggleCameraWindow();

            OnDiceStoppedEvent?.Invoke(); //next turn
        }
        else
        {
            OnDiceStoppedEvent?.Invoke(); // next turn
            _playerManager.SubstractActionPoints(_damagePa);
        }

        detector.EventNumDice.RemoveListener(OnDiceStopped);
    }
}