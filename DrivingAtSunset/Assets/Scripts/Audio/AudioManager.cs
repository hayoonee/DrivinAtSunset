using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// This script manages all the audio aspects of the game.
    /// It playes a audio source on the start of the game and enables playing an audio clip in code from 
    /// anywhere in any script.
    /// </summary>

    public Sound[] sounds;

   // AudioSource audio;
    public static AudioManager instance;

    private void Start()
    {
        Play("Track01");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("duplicate Audiomanager");
            return;
        }
        
        //To help audio manager play audio between scenes without cutting music
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if(s.source == null)
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Update()
    {// if(!audio.isPlaying)
    //    {

    //        Debug.Log("Audio Stopped");
    //        SceneManager.LoadScene(2);
    //    }
    }

    //Add music to any part of code with this command:
    //FindObjectOfType<AudioManager>().Play("*TrackName");
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }
}
