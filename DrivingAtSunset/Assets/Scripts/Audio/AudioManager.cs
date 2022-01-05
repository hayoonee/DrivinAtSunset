using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


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

        DontDestroyOnLoad(gameObject);//to help audio manager play audio between scenes without cutting music

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

    public void Play(string name)
    {
        //Add music to any part of code with this command:
        //FindObjectOfType<AudioManager>().Play("*TrackName");
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }
}
