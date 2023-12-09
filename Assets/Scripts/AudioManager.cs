using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("-----------Audio Source----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("-----------Audio Clip-------------------")]
    public AudioClip backdground;
    public AudioClip death;
    public AudioClip pipeTouch;
    public AudioClip wing;
    public AudioClip checkpoint;
    public AudioClip falling;


    private void Start()
    {
        musicSource.clip = backdground;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
