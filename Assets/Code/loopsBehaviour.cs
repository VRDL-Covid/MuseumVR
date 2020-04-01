using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopsBehaviour : MonoBehaviour
{
    [Header("Inputs")]
    public valveBehaviour hotMIV;
    public valveBehaviour coldMIV;
    public RPVBehaviour RPV;
    public pumpBehaviour MCP;

    public float maxFlow = 7;

    [HideInInspector]
    public float flowRate;
    
    [Header("Ouputs")]
    public LEDarrayBehaviour hotLeg;
    public LEDarrayBehaviour coldLeg;

    [HideInInspector]
    public static float hotLegTemp, coldLegTemp, sgRegionTemp;
    private float coldLegTempTarget;
    private float time = 6;

    private float legMass = 2f;

    void checkFlowState()
    {
        if (MCP.state && ((hotMIV.position>1) &&(coldMIV.position > 1)))
        {
            hotLeg.flowstate = LEDarrayBehaviour.flowstates.forwards;
            coldLeg.flowstate = LEDarrayBehaviour.flowstates.forwards;

            flowRate = Mathf.Min(hotMIV.position, coldMIV.position) * maxFlow/100f*MCP.efficiency;
            coldLeg.rate = flowRate;
            hotLeg.rate = flowRate;

        } else {
            hotLeg.flowstate = LEDarrayBehaviour.flowstates.stop;
            coldLeg.flowstate = LEDarrayBehaviour.flowstates.stop;
            flowRate = 0f;
        }
    }

    void calcLoopTemperatures()
    {
        sgRegionTemp -= (steamGenerator.power / legMass) * RPV.HTC * Time.deltaTime;
        float massTransfer = flowRate * Time.deltaTime;

        if (flowRate > 0f)
        {
            hotLegTemp = (hotLegTemp * (legMass - massTransfer) + RPV.TempOutlet * massTransfer) / legMass;
            sgRegionTemp = (sgRegionTemp * (legMass - massTransfer) + hotLegTemp * massTransfer) / legMass;
            coldLegTemp = (coldLegTemp * (legMass - massTransfer) + sgRegionTemp * massTransfer) / legMass;

        }


        limCheck(ref sgRegionTemp);
        limCheck(ref hotLegTemp);
        limCheck(ref coldLegTemp);

    }

    void limCheck(ref float temp)
    {
        if(temp > 100f)
        {
            temp = 100f;
        }
        if (temp < 0)
        {
            temp = 0;
        }
    }

    private void Update()
    {
        checkFlowState();
        calcLoopTemperatures();
    }



}
