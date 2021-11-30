using UnityEngine;
using System.Collections;


public class Collectables : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public string collectType;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.pitch += Time.deltaTime * 1.5f;
        }
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