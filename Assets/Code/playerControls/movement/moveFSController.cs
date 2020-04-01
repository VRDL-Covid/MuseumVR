using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFSController : MonoBehaviour
{
    public float walkSpeed = 4.0f;
    public float runSpeed = 8.0f;
    public float lookSpeed = 90f;
    public bool canMove = true;
    public bool running = false;

    float timeOfLastBroadcast = 0f;
    public float broadcastRate = 10;

    public bool lookLocked;

    public bool isLocalPlayer = false;
    Vector3 oldPos;
    Quaternion oldRotation;
    Quaternion oldHeadRotation;

    public Vector3 netPosition;
    public Vector3 oldNetPosition;
    public Quaternion netBodyRotation;
    public Quaternion oldNetBodyRotation;
    public Quaternion netHeadRotation;
    public Quaternion oldNetHeadRotation;

    public float posUpdateTime;
    public bool UpdateTime;

    private Transform headTrans;
    


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        running = false;
        headTrans = transform.Find("head");
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleLook();
    }


    void handleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        } else
        {
            running = false;
        }

        if (canMove)
        {
            if (!running)
            {
                transform.Translate(getMoveDirection() * walkSpeed * Time.deltaTime,Space.World);
            } else
            {
                transform.Translate(getMoveDirection() * runSpeed * Time.deltaTime, Space.World);
            }

            
        }
        
    }

    Vector3 getMoveDirection()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }


        return moveDirection.normalized;
    }

    void handleLook()
    {
        if(!lookLocked){
            float horizontal = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0, horizontal, 0));
            headTrans.Rotate(-vertical, 0, 0);
        }
    }

}
