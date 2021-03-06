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
    private AudioSource audio, audioAbmientCoin, audioAbmientTree, audioAbmientCar;
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

        //To help audio manager play audio between scenes without cutting music.
        DontDestroyOnLoad(gameObject);


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
    }



    private void Start()
    {
        StartCoroutine(IStartNextScene());
        if (currentScene.name == "DrivingAtSunset")
        {
            SetAudioCoinVariables();
            SetAudioTreeVariables();
            SetAudioCarVariables();
        }
       
        player.CollectCoin += PlayCoinAmbientAudio;
        player.CollectObstacle += PlayTreeAmbientAudio;

    }


    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if ((currentScene.name == "Level2") && (!audio.isPlaying))
        {
            SceneManager.LoadScene(3);
        }
    }

    public void SetAudioVariables(int i)
    {
        audio = gameObject.AddComponent<AudioSource>();

        if (audio == null)
            return;

        audio.clip = soundsArray[i].clip;
        audio.volume = soundsArray[i].volume;
        audio.pitch = soundsArray[i].pitch;
        audio.loop = soundsArray[i].loop;

        audio.Play();
    }

    public void SetAudioCoinVariables()
    {
        audioAbmientCoin = gameObject.AddComponent<AudioSource>();

        if (audioAbmientCoin == null)
            return;

        audioAbmientCoin.clip = soundsArray[2].clip;
        audioAbmientCoin.volume = soundsArray[2].volume;
        audioAbmientCoin.pitch = soundsArray[2].pitch;
        audioAbmientCoin.loop = soundsArray[2].loop;


    }

    public void SetAudioTreeVariables()
    {
        audioAbmientTree = gameObject.AddComponent<AudioSource>();

        if (audioAbmientCoin == null)
            return;

        audioAbmientTree.clip = soundsArray[3].clip;
        audioAbmientTree.volume = soundsArray[3].volume;
        audioAbmientTree.pitch = soundsArray[3].pitch;
        audioAbmientTree.loop = soundsArray[3].loop;

    }

    public void SetAudioCarVariables()
    {
        audioAbmientCar = gameObject.AddComponent<AudioSource>();

        if (audioAbmientCoin == null)
            return;

        audioAbmientCar.clip = soundsArray[4].clip;
        audioAbmientCar.volume = soundsArray[4].volume;
        audioAbmientCar.pitch = soundsArray[4].pitch;
        audioAbmientCar.loop = soundsArray[4].loop;

        PlayCarAmbientAudio();
    }


    private IEnumerator IStartNextScene()
    {
        currentScene = SceneManager.GetActiveScene();


        if (currentScene.name == "DrivingAtSunset")
        {


                yield return new WaitWhile(() => audio.isPlaying);
                SceneManager.LoadScene(2);
                audio.clip = soundsArray[1].clip;
                audio.pitch = 1;
                audio.Play();
        }
        else if (currentScene.name == "Level2")
        {
            SetAudioCoinVariables();
            SetAudioTreeVariables();
            SetAudioCarVariables();

        }
    }

    private void PlayCoinAmbientAudio()
    {
        audioAbmientCoin.Play();
    }

    private void PlayTreeAmbientAudio()
    {
        audioAbmientTree.Play();
    }
    private void PlayCarAmbientAudio()
    {
        audioAbmientCar.Play();
    }
}

