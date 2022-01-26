using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    /// <summary>
    /// This class is used to define new audio sources that are implemented into the game.
    /// </summary>
    
    public string name;

    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume;
    
    [Range(0.1f, 2.0f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
