using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sevenSegDisplay : MonoBehaviour
{
    public GameObject DP1;
    public GameObject DP2;
    public GameObject DP3;
    public Color displayColour = Color.green;

    public float value;
    float _value = -12345f;
    [Range(0, 3)]
    public int decimalPlaces = 1;

    public sevenSegmentDigit[] digits = new sevenSegmentDigit[4];
    // Start is called before the first frame update
    void Start()
    {
        init();
        updateDigits();
        _value = value;
    }
    
    public enum _state { valid, outOfRange,error};
    public _state state;

    // Update is called once per frame
    void Update()
    {
        if(_value != value)
        {
            updateDigits();
            _value = value;
        }
    }

    void turnOn(GameObject led, Color colour)
    {
        led.GetComponent<Renderer>().material.SetColor("_EmissionColor", colour);
    }

    void turnOff(GameObject led)
    {
        led.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

    public void init()
    {


        foreach (Transform child in transform)
        {
            if (child.name.Contains("decimal1"))
            {
                DP1 = child.gameObject;
            }

            if (child.name.Contains("decimal2"))
            {
                DP2 = child.gameObject;
            }

            if (child.name.Contains("decimal3"))
            {
                DP3 = child.gameObject;
            }

            if (child.name.Contains("segment1"))
            {
                digits[0] = child.GetComponent<sevenSegmentDigit>();
            }

            if (child.name.Contains("segment2"))
            {
                digits[1] = child.GetComponent<sevenSegmentDigit>();
            }

            if (child.name.Contains("segment3"))
            {
                digits[2] = child.GetComponent<sevenSegmentDigit>();
            }

            if (child.name.Contains("segment4"))
            {
                digits[3] = child.GetComponent<sevenSegmentDigit>();
            }

        }

        //set decimal place lamp
        switch (decimalPlaces)
        {
            case 0:
                turnOff(DP1);
                turnOff(DP2);
                turnOff(DP3);
                break;
            case 1:
                turnOff(DP1);
                turnOff(DP2);
                turnOff(DP3);
                turnOn(DP1, displayColour);
                break;
            case 2:
                turnOff(DP1);
                turnOff(DP2);
                turnOff(DP3);
                turnOn(DP2, displayColour);
                break;
            case 3:
                turnOff(DP1);
                turnOff(DP2);
                turnOff(DP3);
                turnOn(DP3, displayColour);
                break;
        }

        

    }


    void setErrorState()
    {
        digits[0].value = sevenSegmentDigit.errorValue;
        digits[1].value = sevenSegmentDigit.errorValue;
        digits[2].value = sevenSegmentDigit.errorValue;
        digits[3].value = sevenSegmentDigit.errorValue;
    }

    void setOORState()
    {
        digits[0].value = sevenSegmentDigit.OORValue;
        digits[1].value = sevenSegmentDigit.OORValue;
        digits[2].value = sevenSegmentDigit.OORValue;
        digits[3].value = sevenSegmentDigit.OORValue;
    }

    void setValidState()
    {
        string valueString;
        string format;
        if (value > 9.999 * Mathf.Pow(10, 3 - decimalPlaces))
        {
            digits[0].value = sevenSegmentDigit.nullValue;
            digits[1].value = sevenSegmentDigit.nullValue;
            digits[2].value = sevenSegmentDigit.nullValue;
            digits[3].value = sevenSegmentDigit.nullValue;
        }
        else
        {
            switch (decimalPlaces)
            {
                case 0:
                    format = "f0";
                    valueString = value.ToString(format);
                    if (Mathf.Abs(value) >= 1000)
                    {
                        digits[0].value = int.Parse(valueString[0].ToString());
                        digits[1].value = int.Parse(valueString[1].ToString());
                        digits[2].value = int.Parse(valueString[2].ToString());
                        digits[3].value = int.Parse(valueString[3].ToString());
                    }
                    if (Mathf.Abs(value) >= 100 && Mathf.Abs(value) < 1000)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = int.Parse(valueString[0].ToString());
                        digits[2].value = int.Parse(valueString[1].ToString());
                        digits[3].value = int.Parse(valueString[2].ToString());
                    }
                    if (Mathf.Abs(value) >= 10 && Mathf.Abs(value) < 100)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = sevenSegmentDigit.nullValue;
                        digits[2].value = int.Parse(valueString[0].ToString());
                        digits[3].value = int.Parse(valueString[1].ToString());
                    }
                    if (Mathf.Abs(value) >= 1 && Mathf.Abs(value) < 10)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = sevenSegmentDigit.nullValue;
                        digits[2].value = sevenSegmentDigit.nullValue;
                        digits[3].value = int.Parse(valueString[0].ToString());
                    }

                    if (Mathf.Abs(value) >= 0 && Mathf.Abs(value) < 1)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = sevenSegmentDigit.nullValue;
                        digits[2].value = sevenSegmentDigit.nullValue;
                        digits[3].value = 0;
                    }

                    break;
                case 1:
                    format = "f1";
                    valueString = value.ToString(format);

                    if (Mathf.Abs(value) >= 100 && Mathf.Abs(value) < 1000)
                    {
                        digits[0].value = int.Parse(valueString[0].ToString());
                        digits[1].value = int.Parse(valueString[1].ToString());
                        digits[2].value = int.Parse(valueString[2].ToString());
                        digits[3].value = int.Parse(valueString[4].ToString());
                    }
                    if (Mathf.Abs(value) >= 10 && Mathf.Abs(value) < 100)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = int.Parse(valueString[0].ToString());
                        digits[2].value = int.Parse(valueString[1].ToString());
                        digits[3].value = int.Parse(valueString[3].ToString());
                    }
                    if (Mathf.Abs(value) >= 1 && Mathf.Abs(value) < 10)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = sevenSegmentDigit.nullValue;
                        digits[2].value = int.Parse(valueString[0].ToString());
                        digits[3].value = int.Parse(valueString[2].ToString());
                    }

                    if (Mathf.Abs(value) >= 0 && Mathf.Abs(value) < 1)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = sevenSegmentDigit.nullValue;
                        digits[2].value = int.Parse(valueString[0].ToString());
                        digits[3].value = int.Parse(valueString[2].ToString());
                    }

                    break;
                case 2:
                    format = "f2";
                    valueString = value.ToString(format);

                    if (Mathf.Abs(value) >= 10 && Mathf.Abs(value) < 100)
                    {
                        digits[0].value = int.Parse(valueString[0].ToString());
                        digits[1].value = int.Parse(valueString[1].ToString());
                        digits[2].value = int.Parse(valueString[3].ToString());
                        digits[3].value = int.Parse(valueString[4].ToString());
                    }
                    if (Mathf.Abs(value) >= 0 && Mathf.Abs(value) < 10)
                    {
                        digits[0].value = sevenSegmentDigit.nullValue;
                        digits[1].value = int.Parse(valueString[0].ToString());
                        digits[2].value = int.Parse(valueString[2].ToString());
                        digits[3].value = int.Parse(valueString[3].ToString());
                    }
                    break;
                case 3:
                    format = "f3";
                    valueString = value.ToString(format);

                    if (Mathf.Abs(value) >= 0 && Mathf.Abs(value) < 10)
                    {
                        digits[0].value = int.Parse(valueString[0].ToString());
                        digits[1].value = int.Parse(valueString[2].ToString());
                        digits[2].value = int.Parse(valueString[3].ToString());
                        digits[3].value = int.Parse(valueString[4].ToString());
                    }
                    break;
                default:
                    format = "";
                    break;
            }
        }
    }

    void updateDigits()
    {
        switch (state)
        {
            case _state.valid:
                setValidState();
                break;
            case _state.outOfRange:
                setOORState();
                break;
            case _state.error:
                setErrorState();
                break;
        }
    }

}
