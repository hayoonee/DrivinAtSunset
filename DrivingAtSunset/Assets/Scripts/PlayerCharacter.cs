using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _transformPlayer;

    [SerializeField] private float _speed = 31.0f;

    private void Start()
    {       
        _rb.velocity = new Vector3(0, 0, _speed);
    }

    void Update()
    {
        _transformPlayer.position = new Vector3(Mathf.Clamp(transform.position.x, -7.0f, 7.0f), transform.position.y, transform.position.z);
        //if (transform.position.x >= 7)      
        //    transform.position = new Vector3(7, transform.position.y, transform.position.z);

        //if (transform.position.x < -7)
        //    transform.position = new Vector3(-7, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("A pressed");

            _transformPlayer.Translate(-0.1f, 0, 0);
        }
       

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("D pressed");
           
            _transformPlayer.Translate(0.1f, 0, 0.0f);
        }
    }

}
