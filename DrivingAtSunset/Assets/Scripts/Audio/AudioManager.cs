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

    public Sound[] soundsArray;
    private Sound sound;
    private AudioSource audio;
    private AudioSource audioCoin;
    public static AudioManager instance;

    private PlayerCharacter player;
    private Scene currentScene;


  
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
        DontDestroyOnLoad(gameObject);
        //To help audio manager play audio between scenes without cutting music.


        Sound s = Array.Find(soundsArray, sound => sound.name == name);


        player = FindObjectOfType<PlayerCharacter>();


        currentScene = SceneManager.GetActiveScene();


        //Sets all the variables of the audio sources.
        if (currentScene.name == "DrivingAtSunset")
        {
            SetAudioVariables(0);
        }

        if (currentScene.name == "Level2")
        {
            SetAudioVariables(1);
        }

        //SetAudioCoinVariables();

        //if (currentScene.name == "EndScene")
        //{
        //    SetVariables(2);
        //}
    }



    private void Start()
    {
        StartCoroutine(StartNextScene());
        SetAudioCoinVariables();

        //player = GetComponent<PlayerCharacter>();
        player.CollectCoin += PlayCoindAudio;
    }

    private void SetAudioVariables(int i)
    {
        audio = gameObject.AddComponent<AudioSource>();

        if (audio == null)
            return;

        audio.clip = soundsArray[i].clip;

        //s.source.name = s.name;
        audio.volume = soundsArray[i].volume;
        audio.pitch = soundsArray[i].pitch;
        audio.loop = soundsArray[i].loop;

        audio.Play();
    }

    public void SetAudioCoinVariables()
    {
        audioCoin = gameObject.AddComponent<AudioSource>();

        if (audioCoin == null)
            return;

        audioCoin.clip = soundsArray[2].clip;

        //s.source.name = s.name;
        audioCoin.volume = soundsArray[2].volume;
        audioCoin.pitch = soundsArray[2].pitch;
        audioCoin.loop = soundsArray[2].loop;

    }


    private IEnumerator StartNextScene()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "Level2")
        {

            yield return new WaitWhile(() => audio.isPlaying);

            SceneManager.LoadScene(2);
            audio.clip = soundsArray[1].clip;
            audio.Play();

            //yield break;

        }

        // Add music to last scene after hyoon did 
        //if ((currentScene.name == "Level2") && (currentScene.name == "EndScene"))
        //{

        //}
    }

    private void PlayCoindAudio()
    {
        audioCoin.Play();
    }

}
