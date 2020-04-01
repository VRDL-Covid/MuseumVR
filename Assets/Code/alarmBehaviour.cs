using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmBehaviour : MonoBehaviour
{

    public bool state;
    bool _state;

    public float blinkRate=2f;
    float time;

    public LEDbehaviour LED;

    private void Awake()
    {
        _state = !state;
    }


    // Update is called once per frame
    void Update()
    {
        if(LED != null)
        {
            if (state)
            {
                flash();
            } else
            {
                LED.setState(false);
            }
            time += Time.deltaTime;
        }
    }

    void flash()
    {
        if (time > 1 / blinkRate)
        {
            time = 0;
            LED.toggle();
        }
    }
}
