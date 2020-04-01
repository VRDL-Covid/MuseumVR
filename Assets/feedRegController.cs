using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedRegController : MonoBehaviour
{
    public valveBehaviour FRV;
    public pumpBehaviour feedPump;
    public float FRVSpeed = 1.0f;

    private float intdL = 0;

    public static float flowRate;

    public float targetSGLevel = 60f;

    public float cP = 1.0f;
    public float cI = 1.0f;


    void calculateFlowRate()
    {
        flowRate = 16.5f * FRV.position/100f* feedPump.efficiency;
    }



    private void Update()
    {
        updateValvePosition();
        calculateFlowRate();
    }

    void updateValvePosition()
    {
        float dL = targetSGLevel - steamGenerator.Level;

        intdL += dL*Time.deltaTime;


        checkLims(-10, 10, ref intdL);

        FRV.position += (dL*cP + intdL*cI) * FRVSpeed* Time.deltaTime;

        checkLims(0, 100, ref FRV.position);
        Debug.Log("SG Level: " + steamGenerator.Level + " | eP: "+ dL*cP + " | eI: " + intdL*cI );
    }


    void checkLims(float min, float max, ref float value)
    {
        if(value > max)
        {
            value = max;
        }

        if (value < min)
        {
            value = min;
        }
    }
}
