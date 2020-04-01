using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressuriserHeaterBehaviour : MonoBehaviour
{
    public LEDbehaviour heaterBulb;
    public bool state;
    public tankBehaviour pressuiser;
    public float heaterPowerRating=1.0f;

    [HideInInspector]
    public float power = 0;

    private bool _state;

    // Start is called before the first frame update
    void Start()
    {
        _state = state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startHeaters()
    {
        state = true;
        heaterBulb.turnOn();
        power = heaterPowerRating;
    }

    public void stopHeaters()
    {
        state = false;
        heaterBulb.turnOff();
        power = 0f;
    }
}
