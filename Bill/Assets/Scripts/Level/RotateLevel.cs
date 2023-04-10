using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    float degrees = 0f;
    float mobileDegrees = 0f;

    public float turnSpeed = 1.5f;

    void Update()
    {
        Debug.Log(mobileDegrees);

        //mobileDegrees = 
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("q") && degrees * turnSpeed <= 89)
        {
            degrees++;
        }
        if (Input.GetKey("e") && degrees * turnSpeed >= -89)
        {
            degrees--;
        }
        transform.rotation = Quaternion.Euler(Vector3.forward * (degrees * 100));
    }
}
