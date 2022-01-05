using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	public Transform[] Positions;
	public Transform Parent;
	public GameObject Object;
	[SerializeField] AudioSource audioSource;

	public Transform Location;

	bool ToSpawn = true;

    void Start()
    {
		Debug.Log(audioSource);
		if(audioSource == null)
        {
			audioSource = GameObject.FindObjectOfType<AudioSource>();

			if (audioSource == null)
			{
				Debug.Log("Audiosource not found");
			}
        }
	}

    void Update()
	{
		if (ToSpawn == true)
		{
			Location = Positions[Random.Range(0, Positions.Length)];
			Collectables collect = Instantiate(Object,Location.position, Quaternion.identity, this.Parent).GetComponent<Collectables>();
			collect?.AssignedAudioSource(audioSource);
			ToSpawn = false;
			StartCoroutine(ToSpawnTrue());
		}	
	}

	IEnumerator ToSpawnTrue()
	{
		yield return new WaitForSeconds(0.75f);
		ToSpawn = true;
		Debug.Log("spawned");
	}
}