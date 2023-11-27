using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private float _lerpRate;

    Vector3 offset; // distance between the cam and the ball

    void Start()
    {
        offset = _ball.transform.position - transform.position;
    }

    void Update()
    {
        if (!GameObject.Find("Ball").GetComponent<BallController>().GameOver)
        {
            Follow();
        }

    }
    void Follow()
    {
        Vector3 currentPosition = transform.position; // temp var to store the current position
        Vector3 targetPosition = _ball.transform.position - offset; //where we want the cam to go
        currentPosition = Vector3.Lerp(currentPosition,targetPosition,_lerpRate * Time.deltaTime);// linearly interpolate between pos and tar
        transform.position = currentPosition;
    }
}