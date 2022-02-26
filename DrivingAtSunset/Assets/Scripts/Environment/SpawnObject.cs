using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	/// <summary>
	/// This script handles the spawning of objects in the scene.
	/// </summary>
	
	public Transform[] Positions;
	public Transform Parent;
	public GameObject Object;
	[SerializeField] AudioSource audioSource;
	//private AudioManager audioManager;
	[SerializeField, Range(0, 3)] float spawnTime;

	public Transform Location;

	bool ToSpawn = true;

	private List<Transform> ObjectList = new List<Transform>();

	void Start()
    {
		//audioManager = FindObjectOfType<AudioManager>();
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

			//destroy when trees/coins are too much
			
			//ObjectList.Add(collect.transform);
			//if (ObjectList.Count > 20)
		    //{
			//	ObjectList.RemoveAt(1);
		    //  Destroy(transform.GetChild(2).gameObject);
			//}

			StartCoroutine(ToSpawnTrue());
		}	
	}

	IEnumerator ToSpawnTrue()
	{
		yield return new WaitForSeconds(spawnTime);
		ToSpawn = true;
		Debug.Log("spawned");

	}
}