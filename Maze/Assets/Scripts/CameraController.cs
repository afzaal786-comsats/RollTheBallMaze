using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offsetCamra;

    // use this for initilization
    void Start()
    {
        offsetCamra = transform.position - ball.transform.position;

    }

    // Late Update is called after all Update() Method are processed
    //Cam will follow character after character update
     void LateUpdate()
    {
        transform.position = ball.transform.position + offsetCamra;

    }
}
