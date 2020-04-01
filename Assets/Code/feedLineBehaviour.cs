using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedLineBehaviour : MonoBehaviour
{

    float flowRate;

    [Header("Ouputs")]
    public LEDarrayBehaviour feedLine;

    void checkFlowRate()
    {
        if (feedRegController.flowRate>0f)
        {
            feedLine.flowstate = LEDarrayBehaviour.flowstates.forwards;
            flowRate = feedRegController.flowRate;
            feedLine.rate = flowRate;
        } else
        {
            feedLine.flowstate = LEDarrayBehaviour.flowstates.stop;
            flowRate = 0f;
        }
    }

    private void Update()
    {
        checkFlowRate();
    }


}
