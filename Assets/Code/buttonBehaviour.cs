using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
    public bool state;
    private bool _state;

    LEDbehaviour LED;

    Vector3 zeroPosition;

    private void Awake()
    {
        zeroPosition = transform.position;
        LED = gameObject.GetComponent<LEDbehaviour>();
        activePlayer.onPlayerLookingExit += lookAway;
    }

    private void Update()
    {
        if(activePlayer.lookedAtObj == gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                state = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                state = false;
            }
        }

        handleLED();
    }

    void handleLED()
    {
        if (_state != state)
        {
            LED.setState(state);
            _state = state;
        }
    }
    
    public void lookAway()
    {
        if(activePlayer._lookedAtObj == gameObject)
        {
            state = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        state = true;
    }

    private void OnTriggerExit(Collider other)
    {
        state = false;
    }
    private void OnDestroy()
    {
        activePlayer.onPlayerLookingExit -= lookAway;
    }
}
