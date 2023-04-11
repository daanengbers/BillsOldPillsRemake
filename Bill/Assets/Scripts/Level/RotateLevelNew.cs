using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateLevelNew : MonoBehaviour
{
    public Text Text;
    public GameObject RotateObj;

    private Quaternion StartRot;
    private Quaternion StartGyro;

    void Start()
    {
        Input.gyro.enabled = true;
        StartGyro = Input.gyro.attitude;
        StartRot = RotateObj.transform.rotation;
        StartGyro.x = 0f;
        StartGyro.y = 0f;
        
        Debug.Log(StartGyro.z);
        Debug.Log(StartRot.z);
    }

    void Update()
    {
        Quaternion RotDiff = Input.gyro.attitude * Quaternion.Inverse(StartGyro) * Quaternion.Euler(0f, 0f, 0f);
        RotDiff.y = 0f;
        RotDiff.x = 0f;
        RotateObj.transform.localRotation = StartRot * RotDiff;

       

        Text.text = (StartRot * Quaternion.Inverse(RotDiff)).ToString();
    }

    public void Recalibrate()
    {
        StartGyro = Input.gyro.attitude;
    }
}
