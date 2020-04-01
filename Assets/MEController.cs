using UnityEngine;

public class MEController : MonoBehaviour
{
    public static float MEPower;
    public static float boatSpeed = 0;
    public TGController TG;

    public sevenSegDisplay demandSpeed;

    float MEDesignPower;

    float steadyStateSpeed;
    

    [Header("Outputs")]
    public dialBehaviour boatSpeedDial;
    public sevenSegDisplay actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MEDesignPower = 80 - (39f);
    }

    // Update is called once per frame
    void Update()
    {
        calculateMEPower();
        calcSteadyStateSpeed();
        calcActualSpeed();
        updateOutputs();
    }

    void calculateMEPower()
    {
        MEPower = steamGenerator.power - (TGController.power/(TG.load1+TG.load2+TG.load3+TG.load4))*39;
    }

    void calcSteadyStateSpeed()
    {
        steadyStateSpeed = Mathf.Lerp(0, 100, MEPower / MEDesignPower);
    }

    void calcActualSpeed()
    {
        boatSpeed += (steadyStateSpeed - boatSpeed) * 0.06f * Time.deltaTime;
    }

    void updateOutputs()
    {
        boatSpeedDial.value = boatSpeed;
        actualSpeed.value = boatSpeed;

        if(boatSpeed < 10f || Mathf.Abs(boatSpeed - demandSpeed.value) > 2)
        {
            boatSpeedDial.alarmState = true;
        } else
        {
            boatSpeedDial.alarmState = false;
        }
    }
}
