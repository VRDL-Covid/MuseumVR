using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressuriser : MonoBehaviour
{
    [Header("pressuriser fluid volume")]
    public tankBehaviour pressuriserWater;
    public pressuriserHeaterBehaviour heaters;

    public valveBehaviour hotMIV;
    public valveBehaviour coldMIV;
    

    public static float Temperature = 30f;
    public static float Pressure = 0;
    public static float Level = 30;

    public float ambientHeatloss = -0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Temperature = pressuriserWater.temperature;
        calcPressure();
    }

    // Update is called once per frame
    void Update()
    {
        calcLevel();
        calcTemperature();
        calcPressure();

    }


    void calcLevel()
    {
        if(hotMIV.position>0 && coldMIV.position > 0)
        {
            Level = Mathf.Lerp(20, 80, (3f*RPVBehaviour.Temperature + 0.5f*loopsBehaviour.hotLegTemp + 0.5f*loopsBehaviour.coldLegTemp) / 4f*3f);
        } else
        {
            //TODO closed MIV behaviour.
        }

        pressuriserWater.level = Level;
    }

    void calcTemperature()
    {
        Temperature += (heaters.power + ambientHeatloss) * Time.deltaTime;

        if (Temperature < 0f)
        {
            Temperature = 0f;
        }

        if (Temperature > 150f)
        {
            Temperature = 150f;
        }
    }


    public static float calcSatPressure(float temp)
    {
        float pow = 5;
        float mult = Mathf.Pow(10f,9f);

        float normaliser = 100f/(Mathf.Pow(150f, pow) + Mathf.Pow(150f, pow - 1f)+150f*mult);

        float press = (Mathf.Pow(temp, pow) + Mathf.Pow(temp, pow - 1f)+temp*mult) * normaliser;


        return press;
    }

    float normalise(float input, float min, float max)
    {
        float m = 1f / (max - min);
        float c = 1f - m * max;

        return (m * input) + c; 
    }

    void calcPressure()
    {
        if (Mathf.Min(hotMIV.position, coldMIV.position) > 1f)
        {
            if (Temperature > RPVBehaviour.Temperature)
            {
                Pressure = calcSatPressure(Temperature);
            }
            else
            {
                Pressure = calcSatPressure(RPVBehaviour.Temperature);
            }
        }
        else
        {
            Pressure = calcSatPressure(Temperature);
        }
    }
}
