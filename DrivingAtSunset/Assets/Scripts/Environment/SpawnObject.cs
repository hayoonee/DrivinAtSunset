using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	public Transform[] Positions;
	public Transform Parent;
	public GameObject Object;

	public Transform Location;

	bool ToSpawn = true;

	
	void Update()
	{
		if (ToSpawn == true)
		{
			Location = Positions[Random.Range(0, Positions.Length)];
			Instantiate(Object,Location.position, Quaternion.identity, this.Parent);
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