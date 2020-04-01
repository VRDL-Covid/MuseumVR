using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamGenerator : MonoBehaviour
{
    public static float Temperature = 30f;
    public static float Pressure = 0;
    public static float Level = 60f;
    public static float power = 0f;

    private float potentialPower;

    [Header("Inputs")]
    public valveBehaviour MSSV;
    public valveBehaviour ME;
    public valveBehaviour TG;
    public tankBehaviour SGWater;

    [Header("Outputs")]
    public dialBehaviour IOSteamPower;

   

    private void Start()
    {
        
    }

    private void Update()
    {

        calcTemp();
        calcPressure();
        calcPotentialPower();
        calcPower();
        calcLevel();
        updateECandI();
    }


    void calcTemp()
    {
        Temperature = Mathf.Lerp(Temperature, loopsBehaviour.sgRegionTemp, 0.25f);
    }

    void calcPressure()
    {
        Pressure = pressuriser.calcSatPressure(Temperature);
    }

    void calcPotentialPower()
    {

        //delta P efficiency;
        float dP = Pressure - condensor.Pressure;
        float pressureEff = 1f;

        if (dP >= 12)
        {
            pressureEff = 1.0f;
        } else
        {
            if(dP<12f && dP >= 10f)
            {
                pressureEff = Mathf.Lerp(0.8f, 1f, (dP - 10f) / (12f-10f));
            }

            if (dP < 10f && dP >= 3f)
            {
                pressureEff = Mathf.Lerp(0f, 0.8f, (dP - 3f) / (10f - 3f));
            }

            if (dP < 3f)
            {
                pressureEff = 0f;
            }
        }

        // level efficiency
        float levelEff = 1.0f;
        if(Level > 40f)
        {
            levelEff = 1.0f;
        } else
        {
            levelEff = Mathf.Lerp(0f, 1f, Level / 40f);
        }

        potentialPower = 130f * pressureEff * levelEff;
    }

    void calcPower()
    {
        power = potentialPower * (MSSV.position / 100f) * ((ME.position / 100f) + (TG.position / 100f));
    }
    void updateECandI()
    {
        IOSteamPower.value = power;
        SGWater.level = Level;
    }

    void calcLevel()
    {
        Level += (feedRegController.flowRate-steamRangeHotBehaviour.flowRate) * Time.deltaTime;
    }
}
