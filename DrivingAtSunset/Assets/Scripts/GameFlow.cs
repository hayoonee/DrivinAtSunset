using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private Transform _tileObj;
    [SerializeField] private Transform _tileObj1;
    [SerializeField] private Transform _tileObj2;
    [SerializeField] private Transform _tileObj3;
    [SerializeField] private Transform _tileObj4;
    [SerializeField] private Transform _tileObj5;
    [SerializeField] private Transform _tileObj6;

    private List<Transform> RoadList = new List<Transform>();
    private Vector3 nextTileSpawn;


    void Start()
    {
        nextTileSpawn.z = 441;
        StartCoroutine(spawnTile());
        
        RoadList.Add(_tileObj);
        RoadList.Add(_tileObj1);
        RoadList.Add(_tileObj2);
        RoadList.Add(_tileObj3);
        RoadList.Add(_tileObj4);
        RoadList.Add(_tileObj5);
        RoadList.Add(_tileObj6);
    }

    void FixedUpdate()
    {
        Debug.Log("List size: " + RoadList.Count);
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(2f);

       var road = Instantiate(_tileObj, nextTileSpawn, _tileObj.rotation);

        road.transform.parent = GameObject.Find("RoadGroup").transform;
        RoadList.Add(road);
  
        nextTileSpawn.z += 63;

        if (RoadList.Count > 25)
        {
            RoadList.RemoveAt(1);
            Destroy(transform.GetChild(1).gameObject);
        }
        
        StartCoroutine(spawnTile());
    }

}
