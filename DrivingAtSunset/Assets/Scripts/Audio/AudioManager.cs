using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
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
    public bool isSceneOver = false;
    private Scene currentScene;

    private void Start()
    {
        Play("Track1");
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
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            Debug.Log("Current sounds are: " + s.name);

            if (s.clip.name == "Track1")
            {
                s.source.enabled = true;
            }
            if (s.name== "Track2")
            {
                s.source.enabled = false;
            }
        }
    }

    public void Update()   
    {
        //never gets enabled
       
        if ((!gameObject.GetComponent<AudioSource>().isPlaying) && (gameObject.GetComponent<AudioSource>().enabled == true))
        {
            Debug.Log("here");
            Playscene2();     
        }  
    }

    private void Playscene2()
    {     
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "EndScene")
        {     
            SceneManager.LoadScene(2);
            foreach (Sound s in sounds)
            {
               
                    if (s.name == "Track1")
                    {
                        s.source.enabled = false;
                    }
                    if (s.name == "Track2")
                    {
                        s.source.enabled = true;

                    }
                //s.source.clip = GetComponent<AudioClip>();
                instance.Play("Track2");
               //FindObjectOfType<AudioManager>().Play("Track2");
            }
        }      
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
