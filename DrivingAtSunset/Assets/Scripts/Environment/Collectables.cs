using UnityEngine;
using TMPro;
using System.Collections;

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
   
    private AudioSource audioSource;

    public CollectType collectType;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            float changePitch = 0;

            switch (collectType)
            {
                case CollectType.up:
                    {
                        changePitch = 0.1f;//need to clamp this number
                    }
                    break;

                case CollectType.down:
                    {
                        changePitch = -0.2f;//need to clamp this number
                    }
                    break;
            }

            audioSource.pitch += changePitch;
            Debug.LogWarning("Pitch at: " + audioSource.pitch);
        }

            Debug.Log(other.gameObject.tag+"_"+other.gameObject.name);
    }

    public void AssignedAudioSource(AudioSource audio)
    {
         
        audioSource = audio;
        
    }
}