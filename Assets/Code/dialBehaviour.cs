using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialBehaviour : MonoBehaviour
{
    public Transform needle;
    public alarmBehaviour alarm;

    public float value;

    public float min = 0f;
    public float max = 100f;

    public float alarmLower = -1.0f;
    public float alarmUpper = 101f;

    public bool alarmState = false;

    private Vector3 zeroRotation;

    private void Awake()
    {
        zeroRotation = needle.localRotation.eulerAngles;
    }

    private void Update()
    {
        needle.localRotation = Quaternion.Euler(zeroRotation.x, zeroRotation.y, zeroRotation.z + Mathf.Lerp(0, 103, (value-min) / max));


        if(value > max)
        {
            value = max;
        }

        if (value < min)
        {
            value = min;
        }

        if(value < alarmLower || value > alarmUpper || alarmState)
        {
            alarm.state = true;
        } else
        {
            alarm.state = false;
        }
    }
}
