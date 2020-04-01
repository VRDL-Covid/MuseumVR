using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;
//using Valve.VR.InteractionSystem;

public class ViveController : MonoBehaviour {
/*
    public SteamVR_Input_Sources inputSource;
    public bool setDebug;
    private bool _holdingObject;

    private Transform _oldParent;
    private GameObject _heldObject;
    private Vector3 _oldPosition;
    private Vector3 _oldRotation;


    private Vector3 _deviceOldPosition;
    private Vector3 _velocity;
    private Vector3 _rotation;

    private float _deviceOldxRotation, _deviceOldyRotation, _deviceOldzRotation;

    //trigger Functions
    public bool getTriggerDown()
    {
         return SteamVR_Input._default.inActions.GrabPinch.GetStateDown(inputSource);
    }

    public bool getTriggerUp()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetStateUp(inputSource);
    }

    public bool getTrigger()
    {
        return SteamVR_Input._default.inActions.GrabPinch.GetState(inputSource);
    }

    public float getTriggerAnalogue()
    {
        return SteamVR_Input._default.inActions.Squeeze.GetAxis(inputSource);
    }


    //Track Pad
    public Vector2 getPadPosition()
    {
        //return SteamVR_Input._default.inActions.TouchPadAnalogue.GetAxis(inputSource);
        return new Vector2(0,0);
    }

    public bool getPadTouched()
    {
        // return SteamVR_Input._default.inActions.TouchPadAnalogueTouch.GetState(inputSource);
        return false;
    }

    public bool getPadButtonDown()
    {
        // return SteamVR_Input._default.inActions.TouchPadButton.GetStateDown(inputSource);
        return false;
    }

    public bool getPadButtonUp()
    {
        //return SteamVR_Input._default.inActions.TouchPadButton.GetStateUp(inputSource);
        return false;
    }

    public bool getPadButton()
    {
        //return SteamVR_Input._default.inActions.TouchPadButton.GetState(inputSource);
        return false;
    }

    //??//polar coords

    // grip buttons
    public bool getGripDown()
    {
        return SteamVR_Input._default.inActions.GrabGrip.GetStateDown(inputSource);
    }

    public bool getGripUp()
    {
        return SteamVR_Input._default.inActions.GrabGrip.GetStateUp(inputSource);
    }

    public bool getGrip()
    {
        return SteamVR_Input._default.inActions.GrabGrip.GetState(inputSource);
    }

    //Menu Button

    public bool getMenuDown()
    {
        return SteamVR_Input._default.inActions.Menu.GetStateDown(inputSource);

    }

    public bool getMenuUp()
    {
        return SteamVR_Input._default.inActions.Menu.GetStateUp(inputSource);

    }

    public bool getMenu()
    {
        return SteamVR_Input._default.inActions.Menu.GetState(inputSource);

    }


    //Haptic Feedback

    public void hapticFeedback(float duration, float Hz, float strength)
    {
        SteamVR_Input._default.outActions.Haptic.Execute(0.0f, duration, Hz, strength, inputSource);
    }




    // Use this for initialization
    void Start () {
     
        setDebug = false;

        if (this.name == "Controller (left)")
        {
            inputSource = SteamVR_Input_Sources.LeftHand;
        }

        if (this.name == "Controller (right)")
        {
            inputSource = SteamVR_Input_Sources.RightHand;
        }

        _deviceOldPosition = transform.position;
        _deviceOldxRotation = transform.rotation.x;
        _deviceOldyRotation = transform.rotation.y;
        _deviceOldzRotation = transform.rotation.z;


    }

    private void calculateVelocity()
    {
        _velocity = (transform.position - _deviceOldPosition) / Time.deltaTime;
        _rotation.x = (transform.rotation.x - _deviceOldxRotation) * 3.141592654f / Time.deltaTime;
        _rotation.y = (transform.rotation.y - _deviceOldyRotation) * 3.141592654f / Time.deltaTime;
        _rotation.z = (transform.rotation.z - _deviceOldzRotation) * 3.141592654f / Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update () {

        calculateVelocity();
        _deviceOldPosition = transform.position;
        _deviceOldxRotation = transform.rotation.x;
        _deviceOldyRotation = transform.rotation.y;
        _deviceOldzRotation = transform.rotation.z;

        if (getGripUp() && _holdingObject)
        {
            if (_heldObject.GetComponent<Rigidbody>() != null)
            {
                _heldObject.GetComponent<Rigidbody>().velocity = _velocity;
                _heldObject.GetComponent<Rigidbody>().isKinematic = false;
                _heldObject.GetComponent<Rigidbody>().angularVelocity = _rotation;
            }
                
            _heldObject.transform.parent = _oldParent;         
            _heldObject = null;
            _holdingObject = false;
        }

        if (getTriggerDown())
        {
            Debug.Log("Pressing trigger");
        }
       
	}

    private void OnTriggerStay(Collider other)
    {
               
        if(other.tag == "pickupAble" )
        {           
            if (getGripDown() && !_holdingObject)
            {
                if (other.transform.parent != null)
                {
                    if(other.transform.parent.tag == "GameController")
                    {
                        return;
                    }
                    _oldParent = other.transform.parent;
                }

                other.transform.parent = transform;
                if (other.GetComponent<Rigidbody>() != null)
                {
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                

                _heldObject = other.transform.gameObject;
                _holdingObject = true;
            }
        }
        
    }
    */
}
