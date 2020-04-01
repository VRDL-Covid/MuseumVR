using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVRcontroller : MonoBehaviour {
    
    
    //Public Variables
    public float movesSpeed;
    public float deadZoneSize = 0.2f;
    public bool allowFlyMode;
    public bool canMove;

    //Private Variables
    private GameObject _camera;
    private GameObject _RController;
    private Vector3 _tempV3;


    //multiplayer Vars
    public float broadcastRate = 10f;
    public float timeOfLastBroadcast = 0;
    //public playerBodyParts localVRPlayer;
    //public multiPlayerClient client;
    bool VRInitialised = false;
   
    // Use this for initialization
    void Start () {

        //initVRParts();

        //client = GameObject.Find("_client").GetComponent<multiPlayerClient>();
        _camera = gameObject.transform.GetChild(2).gameObject;
        _RController = transform.Find("Controller (right)").gameObject; 
        canMove = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (!VRInitialised)
        {
            //initVRParts();
            VRInitialised = true;
        }

        handleMovement();

        //broadcastPosition();

    }
    
    void handleMovement()
    {

    }
}
