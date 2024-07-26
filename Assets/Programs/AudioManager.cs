using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource Sound;
    public AudioClip sg;

    public void PlaySFX(AudioClip clip)
    {
        Sound.PlayOneShot(clip);
    }

}
