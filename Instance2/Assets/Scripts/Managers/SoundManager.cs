using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // Singleton instance


    //private AudioMixer audioSource;

    [Header("---------- Audio Source ----------")]
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource  _sfx;
/*
    [Header("---------- Options Audio ----------")]
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioMixer masterMixer;*/


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        /*audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }*/

        _music.loop = true; 
    }


    private void Start()
    {
        //SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
        //PlaySound(music);
        //PlaySound(SFX);
    }
/*
    public void SetVolume(float value)
    {
        if (value < 1)
        {
            value = .001f;
        }

        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float value)
    {
        soundSlider.value = value;
    }*/

    public void ChangeMusic(AudioClip newClip)
    {
        _music.Stop();
        _music.clip = newClip;
        _music.Play();
    }

    public void PlayMusic(AudioClip soundClip)
    {
        _music.PlayOneShot(soundClip);
    }

    public void PlaySfx(AudioClip soundClip)
    {
        _sfx.PlayOneShot(soundClip);
    }
}