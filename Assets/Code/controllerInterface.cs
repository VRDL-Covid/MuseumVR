using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerInterface : MonoBehaviour
{
    //CRDM control
    [Header("CRDM Settings")]
    public buttonBehaviour controlRodRaise;
    public buttonBehaviour controlRodLower;
    public controlRodBehaviour controlRods;


    //MIV Control
    [Header("MIV Settings")]
    public buttonBehaviour MIVOpen;
    public buttonBehaviour MIVShut;
    public valveBehaviour MIVHot;
    public valveBehaviour MIVCold;

    //MCP Control
    [Header("MCP Settings")]
    public buttonBehaviour MCPStart;
    public buttonBehaviour MCPStop;
    public pumpBehaviour MCP;

    //MCP Control
    [Header("Pressuriser Heater Settings")]
    public buttonBehaviour PRZOn;
    public buttonBehaviour PRZOff;
    public pressuriserHeaterBehaviour heaters;

    //MCP Control
    [Header("SGFeed Settings")]
    public buttonBehaviour SGFStart;
    public buttonBehaviour SGFStop;
    public pumpBehaviour SGF;

    [Header("MSSV Settings")]
    public buttonBehaviour openMSSV;
    public buttonBehaviour shutMSSV;
    public valveBehaviour MSSV;
    bool MSSVManouver = false;

    [Header("ME Throttle Valve Settings")]
    public buttonBehaviour openThrottle;
    public buttonBehaviour shutThrottle;
    public valveBehaviour METV;

    [Header("CW Pump Settings")]
    public buttonBehaviour CWStart;
    public buttonBehaviour CWStop;
    public pumpBehaviour CWPump;




    /// <summary>
    /// CRDM input controller
    /// </summary>
    void handleControlRodInput()
    {
        if(controlRodLower.state && controlRodRaise.state)
        {
            return;
        }

        if (controlRodLower.state )
        {
            controlRods.lower();
        }
        if (controlRodRaise.state)
        {
            controlRods.raise();
        }
    }


    /// <summary>
    /// MIV input controller
    /// </summary>
    void handleMIVInput ()
    {
        if (MIVOpen.state && MIVShut.state)
        {
            return;
        }

        if (MIVOpen.state)
        {
            MIVHot.openValve();
            MIVCold.openValve();
        }
        if (MIVShut.state)
        {
            MIVCold.closeValve();
            MIVHot.closeValve();
        }
    }


    /// <summary>
    /// MCP Input Controller
    /// </summary>
    void handleMCPInput()
    {
        if (MCPStart.state && MCPStop.state)
        {
            return;
        }

        if (MCPStart.state)
        {
            MCP.startPump();
        }

        if (MCPStop.state)
        {
            MCP.stopPump();
        }

    }


    /// <summary>
    /// Pressuriser Heater Input Controller
    /// </summary>
    void handlePRZInput()
    {
        if (PRZOn.state && PRZOff.state)
        {
            return;
        }

        if (PRZOn.state)
        {
            heaters.startHeaters();
        }

        if (PRZOff.state)
        {
            heaters.stopHeaters();
        }

    }


    /// <summary>
    /// MCP Input Controller
    /// </summary>
    void handleSGFInput()
    {
        if (SGFStart.state && SGFStop.state)
        {
            return;
        }

        if (SGFStart.state)
        {
            SGF.startPump();
        }

        if (SGFStop.state)
        {
            SGF.stopPump();
        }

    }


    /// <summary>
    /// MSSV input behaviour
    /// </summary>
    void handleMSSVInput()
    {
        if (openMSSV.state && shutMSSV.state)
        {
            return;
        }

        if (openMSSV.state)
        {
            MSSVManouver = true;
        }

        if (shutMSSV.state)
        {
            MSSVManouver = false;
        }

        if (MSSVManouver && MSSV.position < 100f)
        {
            MSSV.openValve();
        }

        if (!MSSVManouver && MSSV.position > 0f)
        {
            MSSV.closeValve();
        }

    }

    /// <summary>
    /// ME Inuput Behaviour
    /// </summary>
    void handleMEInput()
    {
        if (openThrottle.state && shutThrottle.state)
        {
            return;
        }

        if (openThrottle.state)
        {
            METV.openValve();
        }

        if (shutThrottle.state)
        {
            METV.closeValve();
        }
    }


    /// <summary>
    /// CW Pump Input Behaviour
    /// </summary>
    void handleCWPumpInput()
    {
        if (CWStart.state && CWStop.state)
        {
            return;
        }

        if (CWStart.state)
        {
            CWPump.startPump();
        }

        if (CWStop.state)
        {
            CWPump.stopPump();
        }
    }

    private void Update()
    {
        handleControlRodInput();
        handleMIVInput();
        handleMCPInput();
        handlePRZInput();
        handleSGFInput();
        handleMSSVInput();
        handleMEInput();
        handleCWPumpInput();
    }

}
