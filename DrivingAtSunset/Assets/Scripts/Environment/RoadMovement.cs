using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadMovement : MonoBehaviour
{
    /// <summary>
    /// This script handles the movement of the road (not the car)
    /// </summary>

    [SerializeField] Rigidbody _rb;
    [SerializeField] private float _speed = 31.0f;
    private Scene scene;

    void Start()
    {
        _rb.velocity = new Vector3(0, 0, -_speed);

    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Level2")
        {
            _rb.velocity = new Vector3(0, 0, -_speed / 1.5f);
        }
    }
}
