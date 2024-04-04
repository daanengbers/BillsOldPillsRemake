using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    [SerializeField] private GameObject Level;

    private float xGravity;
    private float yGravity;
    private float angle;

    public float lerpAmount = 1;
    public float turnModyfier = 120;

    bool first = true;
    Vector3 previousAccel = Vector3.zero;

    private bool accelerometerEnabled;

    // Start is called before the first frame update
    void Start()
    {
        accelerometerEnabled = EnableAccelerometer();
    }

    //Check if gyroscope is supported
    private bool EnableAccelerometer()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            return true;
        }
        return false;
    }

    Vector3 GetSmoothedAcceleration()
    {
        if (first)
        {
            previousAccel = Input.acceleration;
            first = false;
        }

        Vector3 smoothedAccel = Vector3.Lerp(Input.acceleration, previousAccel, lerpAmount);
        previousAccel = smoothedAccel;
        return smoothedAccel;
    }


void Update()
    {
        //set angle to accelerometer data
        angle = Mathf.Clamp(GetSmoothedAcceleration().x * turnModyfier, -90, 90); 

        //set level rotation to angle
        Level.transform.rotation = Quaternion.Euler(0, 0, -angle);

        //set gravity to rotation
        xGravity =  -angle * (9.8f/90);
        yGravity = -9.8f + (Mathf.Abs(-angle * (9.8f/90)));

        Debug.Log(xGravity);
        Debug.Log(yGravity);

        //Physics2D.gravity = new Vector2(xGravity, yGravity);
    }
}
