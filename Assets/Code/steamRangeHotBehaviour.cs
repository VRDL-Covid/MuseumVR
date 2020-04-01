using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamRangeHotBehaviour : MonoBehaviour
{
    [Header("Inputs")]

    public LEDarrayBehaviour SRhot;
    public static float flowRate;

    private void Start()
    {
        
    }

    private void Update()
    {
        flowRate = 16f * steamGenerator.power / 100f;

        if (steamGenerator.power > 2f)
        {

            SRhot.flowstate = LEDarrayBehaviour.flowstates.forwards;
            SRhot.rate = flowRate;
        } else
        {
            SRhot.flowstate = LEDarrayBehaviour.flowstates.stop;
        }
            
    }

}
