using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPVBehaviour : MonoBehaviour
{
    [Header("Inputs")]
    public controlRodBehaviour controlRods;

    public loopsBehaviour loops;
    public valveBehaviour hotMIV;
    public valveBehaviour coldMIV;
    public pressuriserHeaterBehaviour heaters;


    [Header("Outputs")]
    public dialBehaviour IReactorPower;
    public dialBehaviour IReactorTemperature;
    public dialBehaviour IReactorPressure;


    public static float Temperature = 0f;
    public static float Power = 0;
    public static float Pressure = 0f;

    [HideInInspector]
    public float TempOutlet = 0f;
    [HideInInspector]
    public float TempCoreRegion = 0f;
    [HideInInspector]
    public float TempInlet = 0f;

    private float OutletMass = 5f;
    private float CoreRegionMass = 5f;
    private float InletMass = 5f;

    public float CR = 1f;
    public float TM = 1f;
    public float HTC = 2f;

    private float timeOutsideSafe = 0f;



    private void Start()
    {
        Power = steamGenerator.power;
    }



    void updateOutputs()
    {
        IReactorTemperature.value = Temperature;
        IReactorPressure.value = Pressure;
        IReactorPower.value = Power;
    }

    #region Reactor Power Calculation


    float temperatureReactivityFeedback()
    {
        return Mathf.Lerp(80f, 0f, TempCoreRegion / 100f); ;
    }

    float controlRodReactivityFeedback()
    {
       return Mathf.Lerp(-100f, 0f, controlRodBehaviour.position / 100f);
    }

    void calcReactorPower()
    {
        float dP;
        dP = (temperatureReactivityFeedback() * TM + controlRodReactivityFeedback() * CR) * 1f * Time.deltaTime;

        checkLims(ref dP, -0.5f, 0.5f);

        Power += dP;

        if (Power < 0)
        {
            Power = 0;
        }

        if(Power > 100f)
        {
            Power = 100f;
        }
    }
    #endregion


    #region Reactor Temperature Calculation

    void calcReactorTemp()
    {
        float loopFlow = loops.flowRate;
        float internalFlow = 1f * Time.deltaTime;
        float massTransfer = loopFlow * Time.deltaTime;

        TempCoreRegion += (Power/CoreRegionMass)* HTC * Time.deltaTime;

        if (loopFlow > 0.1)
        {
            TempOutlet = (TempOutlet * (OutletMass - massTransfer) + TempCoreRegion * massTransfer)/OutletMass;
            TempCoreRegion = (TempCoreRegion * (CoreRegionMass - massTransfer) + TempInlet * massTransfer) / CoreRegionMass;
            TempInlet = (TempInlet * (InletMass - massTransfer) + loopsBehaviour.coldLegTemp * massTransfer) / InletMass;

        } else
        {
            TempOutlet = (TempOutlet * (OutletMass - internalFlow) + TempCoreRegion * internalFlow) / OutletMass;
            TempCoreRegion = (TempCoreRegion * (CoreRegionMass - internalFlow) + TempInlet * internalFlow) / CoreRegionMass;
            TempInlet = (TempInlet * (InletMass - internalFlow) + TempOutlet * internalFlow) / InletMass;
        }

        Temperature = Mathf.Max(TempCoreRegion, TempInlet, TempOutlet);
    }


    void reactorPressureCalc()
    {
        if (Mathf.Min(hotMIV.position, coldMIV.position) > 1)
        {
            Pressure = pressuriser.Pressure;
        }
        else
        {
            /// solid calculation
        }
    }


    void protection()
    {
        if (Power > 95f || Temperature >90f || Pressure >80f || Pressure <20f)
        {
            if (timeOutsideSafe > 2f)
            {
                controlRods.scram();
                if (Pressure > 80f)
                {
                    heaters.stopHeaters();
                }
            }
            timeOutsideSafe += Time.deltaTime;
        } else
        {
            timeOutsideSafe = 0f;
        }
    }

    #endregion
    // Update is called once per frame
    void Update()
    {
        calcReactorPower();
        calcReactorTemp();
        reactorPressureCalc();
        protection();
        updateOutputs();
    }


    void checkLims(ref float val, float min, float max)
    {
        if(val > max)
        {
            val = max;
        }

        if(val < min)
        {
            val = min;
        }
    }





}
