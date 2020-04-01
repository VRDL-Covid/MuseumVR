using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sevenSegmentDigit : MonoBehaviour
{

    //bit objects
    public GameObject[] bits = new GameObject[7];

    public Color LEDColour;
    
    public int value;
    int _value =-1;


    public static int nullValue = 10;
    public static int errorValue = 11;
    public static int OORValue = 12;

    private const int _nullValue = 10;
    private const int _errorValue = 11;
    private const int _OORValue = 12;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<bits.Length; i++)
        {
            if (bits[i] == null)
            {
                bits[i] = transform.GetChild(i).gameObject;
            }
        }

        setbits();
        _value = value;
    }

    void turnOn(GameObject led)
    {
        led.GetComponent<Renderer>().material.SetColor("_EmissionColor", LEDColour);
    }

    void turnOff(GameObject led)
    {
        led.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }


    void resetBits()
    {
        for(int i = 0; i<bits.Length; i++)
        {
            turnOff(bits[i]);
        }
    }

    void setbits()
    {
        resetBits();
        
        switch (value)
        {
            case 0:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[2]);
                turnOn(bits[4]);
                turnOn(bits[5]);
                turnOn(bits[6]);
                break;
            case 1:
                turnOn(bits[2]);
                turnOn(bits[5]);
                break;
            case 2:
                turnOn(bits[0]);
                turnOn(bits[2]);
                turnOn(bits[3]);
                turnOn(bits[4]);
                turnOn(bits[6]);
                break;
            case 3:
                turnOn(bits[0]);
                turnOn(bits[2]);
                turnOn(bits[3]);
                turnOn(bits[5]);
                turnOn(bits[6]);
                break;
            case 4:
                turnOn(bits[1]);
                turnOn(bits[2]);
                turnOn(bits[3]);
                turnOn(bits[5]);
                break;
            case 5:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[3]);
                turnOn(bits[5]);
                turnOn(bits[6]);
                break;
            case 6:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[3]);
                turnOn(bits[4]);
                turnOn(bits[5]);
                turnOn(bits[6]);
                break;
            case 7:
                turnOn(bits[0]);
                turnOn(bits[2]);
                turnOn(bits[5]);
                break;
            case 8:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[2]);
                turnOn(bits[3]);
                turnOn(bits[4]);
                turnOn(bits[5]);
                turnOn(bits[6]);
                break;
            case 9:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[2]);
                turnOn(bits[3]);
                turnOn(bits[5]);
                break;
            case _nullValue:
                
                break;
            case _errorValue:
                turnOn(bits[0]);
                turnOn(bits[1]);
                turnOn(bits[3]);
                turnOn(bits[4]);
                turnOn(bits[6]);
                break;
            case _OORValue:
                turnOn(bits[3]);
                break;

        }
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(value != _value)
        {
            /*
            if (value>10 || value < 0)
            {
                value = _errorValue;
            }
            */
            setbits();
            _value = value;
        }
    }
}
