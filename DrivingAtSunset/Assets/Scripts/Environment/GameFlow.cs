using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    /// <summary>
    /// This script handles how the tiles of the road is spawned and how they move.
    /// </summary>

    [SerializeField] private Transform _tileObj, _tileObj1, _tileObj2, _tileObj3, _tileObj4, _tileObj5, _tileObj6;

    private Scene scene;
    private List<Transform> RoadList;
    private Vector3 nextTileSpawn;


    void Start()
    {
        nextTileSpawn.z = 441;
        StartCoroutine(spawnTile());
        RoadList = new List<Transform> { _tileObj, _tileObj1, _tileObj2,
                                        _tileObj3, _tileObj4, _tileObj5, _tileObj6
        };
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();
    }

    //Coroutine to spawn the tiles
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(2f);

        nextTileSpawn.z = 63f + RoadList[RoadList.Count - 1].position.z;
        var road = Instantiate(_tileObj, nextTileSpawn, _tileObj.rotation);

        road.transform.parent = GameObject.Find("RoadGroup").transform;
        RoadList.Add(road);

        if (scene.name == "Level2")
        {
            if (RoadList.Count > 55)
            {
                RoadList.RemoveAt(1);
                //Destroy(transform.GetChild(1).gameObject);
                Destroy(transform.GetChild(2).gameObject);
            }
        }
        else if (scene.name == "DrivingAtSunset")
        {
            //List to destroy roads if there are more than 15 of them.
            if (RoadList.Count > 15)
            {
                RoadList.RemoveAt(1);
                //Destroy(transform.GetChild(1).gameObject);
                Destroy(transform.GetChild(2).gameObject);
            }
        }




        StartCoroutine(spawnTile());
    }

}
