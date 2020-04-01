using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGController : MonoBehaviour
{

    public static float power = 0;

    [Header("Load1")]
    public pumpBehaviour pump1;
    public float load1;

    [Header("Load2")]
    public pumpBehaviour pump2;
    public float load2;

    [Header("Load3")]
    public pumpBehaviour pump3;
    public float load3;

    [Header("Pressuriser Heater")]
    public pressuriserHeaterBehaviour heaters;
    public float load4;


    public valveBehaviour TG;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        power = 0f;

        if (pump1.state)
        {
            power += load1;
        }

        if (pump2.state)
        {
            power += load2;
        }

        if (pump3.state)
        {
            power += load3;
        }

        if (heaters.state)
        {
            power += load4;
        }

        TG.position = power;
    }
}
