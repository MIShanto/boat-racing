using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainController : MonoBehaviour
{
    public Vector3 COM;
    public float speed = 1.0f;
    public float rotatespeed = 2.0f;
    public float movementThresold = 10.0f;

    private Transform m_com;
    float verticalInput;
    float horizontalInput;
    float movementFactor;
    float movementFactorforSteer;

    private void Update()
    {
        Balance();
        Movement();
        Steer();
    }

    private void Steer()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        movementFactorforSteer = Mathf.Lerp(movementFactorforSteer,  horizontalInput , Time.deltaTime / movementThresold);
        transform.Rotate(0.0f, movementFactorforSteer * rotatespeed, 0.0f);
        //transform.Translate(0.0f, 0.0f, movementFactorforSteer * speed);
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
        transform.Translate(movementFactor * speed, 0.0f, 0.0f);
    }

    private void Balance()
    {
        if(!m_com)
        {
            m_com = new GameObject("COM").transform;
            m_com.SetParent(transform);
        }
        m_com.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_com.position;
    }
}
