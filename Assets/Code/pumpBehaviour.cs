using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpBehaviour : MonoBehaviour
{

    public Transform impeller;
    public LEDbehaviour LED;

    public bool state;
    private bool _state;
    public float maxSpeed = 4f;

    private float time;
    public float coastTime;

    public float efficiency;
    // Start is called before the first frame update
    void Start()
    {
        _state = state;
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == true)
        {
            if (time < coastTime)
            {
                impeller.RotateAroundLocal(Vector3.up, Mathf.Lerp(0, maxSpeed * Time.deltaTime, time / coastTime));
                efficiency = Mathf.Lerp(0, 1, time / coastTime);
            } else {
                impeller.RotateAroundLocal(Vector3.up, maxSpeed * Time.deltaTime);
                efficiency = 1.0f;
            }
            
            LED.turnOn();
        } else
        {
            LED.turnOff();

            if (time < coastTime)
            {
                impeller.RotateAroundLocal(Vector3.up, Mathf.Lerp(maxSpeed * Time.deltaTime,0, time / coastTime));
                efficiency = Mathf.Lerp(1, 0, time / coastTime);
            }

        }

        time += Time.deltaTime;
    }
    

    public void startPump()
    {
        state = true;
        if(_state != state)
        {
            time = 0f;
            _state = state;
        }       
        
    }

    public void stopPump()
    {
        state = false;
        if (_state != state)
        {
            time = 0f;
            _state = state;
        }
    }


}
