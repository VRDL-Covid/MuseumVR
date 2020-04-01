using UnityEngine;

public class LEDbehaviour : MonoBehaviour
{
    Material LED;
    // Start is called before the first frame update
    public bool state;
    private bool _state;
    public float intensity  = 2.0f;
    private float _intensity = 0.0f;
    public Color LEDColour, offColour;

    public bool offColorOveride;

    void Awake()
    {
        LED = gameObject.GetComponent<Renderer>().material;
        _state = !state;
        LEDColour = LED.GetColor("_EmissionColor");
        //offColour = new Color(0, 0, 0);

        if (!offColorOveride)
        {
            offColour = (LEDColour) * 0.2f;
        }
        
        LED.SetColor("_BaseColor", offColour);
    }


    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            if(intensity != _intensity || _state != state)
            {
                LED.SetColor("_EmissionColor", LEDColour * intensity);
                _intensity = intensity;
                _state = state;
            }
        } else
        {
            if (intensity != _intensity || _state != state)
            {
                LED.SetColor("_EmissionColor", offColour);
                _intensity = intensity;
                _state = state;
            }
        }
    }

    public void turnOn()
    {
        LED.SetColor("_EmissionColor", LEDColour * intensity);
        state = true;
    }

    public void turnOff()
    {
        LED.SetColor("_EmissionColor", offColour);
        state = false;
    }

    public void toggle()
    {
        if (state)
        {
            turnOff();
        } else
        {
            turnOn();
        }
    }

    public void setState(bool input)
    {
        if (input)
        {
            turnOn();
        }
        else
        {
            turnOff();
        }
    }

    public void updateLED()
    {
        if (state)
        {
            LED.SetColor("_EmissionColor", LEDColour * intensity);
        }
        else
        {
            LED.SetColor("_EmissionColor", offColour);
        }
        
    }
}
