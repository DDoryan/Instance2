using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSCRIPTAUDIO : MonoBehaviour
{
    [SerializeField] private AudioClip _music;
    [SerializeField] private AudioClip _deathBell;

    void Start()
    {
        SoundManager.Instance.PlayMusic(_music);
        SoundManager.Instance.PlaySfx(_deathBell);
    }
}