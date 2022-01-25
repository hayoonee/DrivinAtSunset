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
   private AudioSource audioSource;

    public CollectType collectType;


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            float changePitch = 0;

            switch (collectType)
            {
                case CollectType.up:
                    {
                        changePitch = 0.1f;                     
                    }
                    break;

                case CollectType.down:
                    {
                        changePitch = -0.2f;
                    }
                    break;
            }

            audioSource.pitch += changePitch;
        }

            Debug.Log(other.gameObject.tag+"_"+other.gameObject.name);
    }

    public void AssignedAudioSource(AudioSource audio)
    {
        audioSource = audio;
        
    }


    /*Still road:
     * 
     * for each coin that spanws 
     * move back to car and play sound for each collected coin
     * 
     */

    /*Moving road:
     * 
     * each beat (where you want coin to be collected) needs to be at a specific location
     * specific location is hard to predetermin on a random location
     * 
     */

}