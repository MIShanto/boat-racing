﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingScript : MonoBehaviour
{
    public float waterlvl = 0.0f;
    public float floatThreshold  = 2.0f;
    public float waterDensity  = 0.125f;
    public float downforce  = 4.0f;
    private float forceFactor;
    private Vector3 floatForce;

    
    void FixedUpdate()
    {
        forceFactor = 1.0f - ((transform.position.y - waterlvl) / floatThreshold);
        if(forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downforce * GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }
}
