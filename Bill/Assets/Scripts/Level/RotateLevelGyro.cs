using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevelGyro : MonoBehaviour
{

    public float tiltAmount = 1.2f;

    /*private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        Vector3 previousEulerAngles = transform.eulerAngles;
        Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

        Vector3 targetEulerAngles = previousEulerAngles + (-gyroInput * tiltAmount) * Time.deltaTime * Mathf.Rad2Deg;
        targetEulerAngles.x = 0.0f; // Only this line has been added
        targetEulerAngles.y = 0.0f;

        transform.eulerAngles = targetEulerAngles;
    }*/
    private void Awake()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);

        Debug.Log(Input.gyro.attitude.z * Mathf.Rad2Deg);

    }

    Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(0f, 0f, -q.z * tiltAmount, -q.w);
    }


}
