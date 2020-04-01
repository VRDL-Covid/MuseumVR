using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankBehaviour : MonoBehaviour
{
    public float temperature = 50;
    public float level = 50;
    public float pressure = 50;

    private float _temperature, _pressure, _level = 0;

    private int numLEDs;


    public List<LEDbehaviour> LEDs = new List<LEDbehaviour>();
    // Start is called before the first frame update
    void Awake()
    {
        _temperature = temperature;

        foreach(Transform child in transform)
        {
            if(child.GetComponent<LEDbehaviour>() != null)
            {
                LEDs.Add(child.GetComponent<LEDbehaviour>());
            }
        }

        numLEDs = LEDs.Count;


    }

    private void Start()
    {
        setLevel();
        setTemperature();
    }

    // Update is called once per frame
    void Update()
    {
        setLevel();
        setTemperature();
    }


    void setLevel()
    {

        if(level > 100f)
        {
            level = 100f;
        }

        if (level < 0f)
        {
            level = 0;
        }

        if (_level != level)
        {
            for (int i = 0; i < numLEDs; i++)
            {
                LEDs[i].turnOff();
            }

            for (int i = 0; i<((level/100f)*numLEDs); i++)
            {
                LEDs[i].turnOn();
            }
        }
    }

    void setTemperature()
    {

        if (temperature > 100f)
        {
            temperature = 100f;
        }

        if (temperature < 0)
        {
            temperature = 0f;
        }

        if(_temperature != temperature){
            Color hot = new Color(1.0f, 0, 0);
            Color mid = new Color(1f, 1f, 0);
            Color cold = new Color(0, 0, 1.0f);
            Color actual = new Color();

            if (temperature <= 50.0)
            {
                actual = Color.Lerp(cold, mid, temperature / 50f);
            } else
            {
                actual = Color.Lerp(mid, hot, (temperature-50f) / 50f);
            }
            

            foreach(LEDbehaviour LED in LEDs)
            {
                LED.LEDColour = actual;
                LED.offColour = actual * 0.1f;
                LED.updateLED();
            }
        }
        
    }
}
