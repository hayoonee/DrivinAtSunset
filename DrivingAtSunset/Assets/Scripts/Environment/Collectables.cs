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

}