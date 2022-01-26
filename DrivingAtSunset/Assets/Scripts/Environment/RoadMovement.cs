using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    /// <summary>
    /// This script handles the movement of the road (not the car)
    /// </summary>

    [SerializeField] Rigidbody _rb;
    [SerializeField] private float _speed = 31.0f;

    void Start()
    {
        _rb.velocity = new Vector3(0, 0, -_speed);
    }

 
   
}
