using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condensor : MonoBehaviour
{
    public pumpBehaviour CWPump;
    public pumpBehaviour feedPump;

    public tankBehaviour condensorWater;
    public static float Temperature;
    public static float Pressure;
    public static float Level = 40;

    public dialBehaviour condPressureOut;


    // Start is called before the first frame update
    void Start()
    {
        Temperature = condensorWater.temperature;
        condensorWater.level = Level;
    }

    // Update is called once per frame
    void Update()
    {
        calcTemp();
        calcPres();
        updateLevel();
        ECandIUpdate();
    }
    

    void calcTemp()
    {
        float CWPow = 0f;
        if (CWPump.state)
        {
            CWPow = 105f;
        } else
        {
            CWPow = 0f;
        }


        float dT = (steamGenerator.power - CWPow) * Time.deltaTime;
        Temperature += dT*0.1f;
        limCheck(ref Temperature);
    }

    void calcPres()
    {
        Pressure = pressuriser.calcSatPressure(Temperature);
    }

    void limCheck(ref float temp)
    {
        if (temp > 100f)
        {
            temp = 100f;
        }
        if (temp < 0)
        {
            temp = 0;
        }
    }


    void ECandIUpdate()
    {
        condPressureOut.value = Pressure;
        condensorWater.level = Level;
    }

    void updateLevel()
    {
        Level += (steamRangeHotBehaviour.flowRate - feedRegController.flowRate) * Time.deltaTime;

        limCheck(ref Level);
    }
}
