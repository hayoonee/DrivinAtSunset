using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public enum CollectType
{
    up,
    down
}

public class Collectables: MonoBehaviour
{
    /// <summary>
    /// This script handles the properties of the collectables, 
    /// whether they increase or decrease the pitch of the audio.
    /// </summary>
   
    [SerializeField] private AudioSource audioSource, audioSource2;
    private Scene currentScene;

    public CollectType collectType;
    private AudioManager audioManager;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level2")
        {
            audioManager = FindObjectOfType<AudioManager>();
            audioSource2 = audioManager.GetComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Destroy(audioSource2);
        }
    }


    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            float changePitch = 0;
            Debug.Log("AudioSource is: " + audioSource.clip.name);
           
            if (currentScene.name == "Level2")
            {
                audioSource = audioSource2;
            }

  

            switch (collectType)
            {
                case CollectType.up:
                    {
                        changePitch = 0.01f;
                        
                    }
                    break;

                case CollectType.down:
                    {
                        changePitch = -0.05f;
                    }
                    break;
            }

            audioSource.pitch += changePitch;
            Debug.LogWarning("Pitch " + audioSource.clip.name + " is at: " + audioSource.pitch);
        }

            Debug.Log(other.gameObject.tag+"_"+other.gameObject.name);
    }

    public void AssignedAudioSource(AudioSource audio)
    {
         
        audioSource = audio;
        
    }
}