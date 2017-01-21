using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundOnMouseDown : MonoBehaviour {

    [SerializeField]
    AudioClip soundToPlay;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {

        audio.PlayOneShot(soundToPlay, 0.7F);
    }
}
