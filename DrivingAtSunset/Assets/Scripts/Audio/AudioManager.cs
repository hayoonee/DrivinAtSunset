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

    private AudioSource audio;
    public static AudioManager instance;
    
    private Scene currentScene;

    private float clipTime;
    private void Start()
    {
        StartCoroutine(StartNextScene());
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

        currentScene = SceneManager.GetActiveScene();

        //Sets all the variables of the audio clips.
        if (currentScene.name == "DrivingAtSunset")
        {
            SetVariables(0);
        }

        if (currentScene.name == "Level2")
        {
            SetVariables(1);
        }
        
        //if (currentScene.name == "EndScene")
        //{
        //    SetVariables(2);
        //}
    }


    private void SetVariables(int i)
    {
        audio = gameObject.AddComponent<AudioSource>();

        if (audio == null)
            return;

        audio.clip = sounds[i].clip;

        //s.source.name = s.name;
        audio.volume = sounds[i].volume;
        audio.pitch = sounds[i].pitch;
        audio.loop = sounds[i].loop;
        
            Debug.Log("loot at me");
            audio.Play();
    
    }

    private IEnumerator StartNextScene()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "Level2")
        {
                 
            yield return new WaitWhile(() => audio.isPlaying);
            
            SceneManager.LoadScene(2);
            audio.clip = sounds[1].clip;
            audio.Play();

            //yield break;

        }

        // Add music to last scene after hyoon did 
        //if ((currentScene.name == "Level2") && (currentScene.name == "EndScene"))
        //{
            
        //}
    }

    //Add music to any part of code with this command:
    //FindObjectOfType<AudioManager>().Play("*TrackName");
    //Doens't work anymore, changed architechture
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
