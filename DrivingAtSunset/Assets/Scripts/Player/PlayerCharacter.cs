using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// This script handles the player's ability to move the character.
    /// </summary>
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _transformPlayer;

    [SerializeField] private float _speed = 31.0f;
    public List<string> collects;

    public event System.Action CollectCoin;
    public event System.Action CollectObstacle;


    private void Start()
    {       
        collects = new List<string>();
    }
    
    void Update()
    {
        _transformPlayer.position = new Vector3(Mathf.Clamp(transform.position.x, -7.0f, 7.0f), transform.position.y, transform.position.z);
  
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _transformPlayer.Translate(-0.15f, 0.0f, 0.0f);
        }
      
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _transformPlayer.Translate(0.15f, 0.0f, 0.0f);
        }
    }

    //Collision with the collectables destroy them.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectCoin?.Invoke();      
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            CollectObstacle?.Invoke();
        }

        if ((other.gameObject.CompareTag("Coin")) || (other.gameObject.CompareTag("Tree")))
        {
            string collectsType = System.Enum.GetName(typeof(CollectType), other.gameObject.GetComponent<Collectables>().collectType);
            collects.Add(collectsType);
            Destroy(other.gameObject);
        }
    }
}
