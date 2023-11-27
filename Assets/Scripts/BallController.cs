using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _sparkles;
    Rigidbody rigidBody;
    private bool _started;
    
    public bool GameOver; //change for global later?

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        _started = false;
        GameOver = false;
    }

    void Update()
    {
        if (!_started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidBody.velocity = new Vector3(_speed, 0, 0);
                _started = true;

                GameManager.instance.StartGame();
            }
        }
        if(Input.GetMouseButtonDown(0) && !GameOver)
        {
            SwitchDirections();
        }
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            rigidBody.velocity = new Vector3(0, -_speed, 0);

            GameManager.instance.GameOver();
        };   
    }
  
    void SwitchDirections()
    {
        if (rigidBody.velocity.z>0)
        {
            rigidBody.velocity = new Vector3(_speed, 0, 0);
        }
        else if (rigidBody.velocity.x > 0)
        {
            rigidBody.velocity = new Vector3(0, 0, _speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Diamond")
        {
            GameObject particles = Instantiate(_sparkles, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(particles, 1f);
        }
    }
}