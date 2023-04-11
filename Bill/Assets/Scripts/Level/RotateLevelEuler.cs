using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateLevelEuler : MonoBehaviour
{
    private bool gyroEnabled;
    private UnityEngine.Gyroscope gyro;
    private GameObject GyroControl;
    private Quaternion rot;
    public Text text;

    Transform t;

    public bool Zmode = false;

    float Zangle;

    public bool Switch = false;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        GyroControl = new GameObject("Gyro Control");
        GyroControl.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        transform.SetParent(GyroControl.transform); //parents the object to an empty control object
        gyroEnabled = EnableGyro();

        t = transform;
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            GyroControl.transform.rotation = Quaternion.Euler(90f, -90f, 0f); //These offset values are essential for the gyroscope to orientate itself correctly
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
    private void Update()
    {
        if (gyroEnabled == true && Zmode == true)
        {

            transform.localRotation = gyro.attitude * rot;
            Zangle = t.eulerAngles.z;
            t.eulerAngles = new Vector3(0, 0, Zangle);
        }
    }



    public void DisplayZangles()
    {
        if (Switch == false)
        {
            text.text = Mathf.Abs(Zangle).ToString("0") + "°";
        }

        else if (Switch == true)
        {
            if (90 + Zangle <= 90)
                text.text = Mathf.Abs(90 + Zangle).ToString("0") + "°";
            else
                text.text = Mathf.Abs(Zangle - 90).ToString("0") + "°";
        }
    }

    public void SetXmodeToTrue()
    {
        Zmode = false;
    }

    public void SwitchWhenPressed()
    {
        if (Switch == false)
            Switch = true;
        else
            Switch = false;
    }
}
