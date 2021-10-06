using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _transformPlayer;

    private void Start()
    {       
        _rb.velocity = new Vector3(0, 0, 31.0f);
    }

    void Update()
    {
        _transformPlayer.position = new Vector3(Mathf.Clamp(transform.position.x, -7.0f, 7.0f), transform.position.y, transform.position.z);
        //if (transform.position.x >= 7)      
        //    transform.position = new Vector3(7, transform.position.y, transform.position.z);

        //if (transform.position.x < -7)
        //    transform.position = new Vector3(-7, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");

            _transformPlayer.Translate(-0.1f, 0, 0);
        }
       

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D pressed");
           
            _transformPlayer.Translate(0.1f, 0, 0.0f);
        }
    }

}
