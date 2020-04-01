
using UnityEngine;
using UnityEngine.UI;

public class activePlayer : MonoBehaviour
{
    private static activePlayer _instance;
    public static GameObject _gameObject;
    public static activePlayer Instance { get { return _instance; } }

    public static GameObject _Camera;
    private static Vector3 _diff;
    public static GameObject _loadingScreen;
    public static Slider _loadingBar;
    public static GameObject playerRig;
    public static GameObject rHand;
    public static GameObject lHand;

    public static bool canMove, running;


    public enum playerTypes { VR, flatScreen };

    public static playerTypes playerType;
    public playerTypes selectedPlayerType;


    public static Vector3 nextPosition;

    public float walkSpeed = 1.0f;
    public float runSpeed = 3.0f;
    public float lookSpeed = 1.0f;



    /// <summary>
    /// Looking Event system
    /// </summary>
    static bool looking, _looking;
    public static GameObject lookedAtObj, _lookedAtObj;

    public delegate void playerLooking();
    public static playerLooking onPlayerLooking;

    public delegate void playerLookingEnter();
    public static playerLookingEnter onPlayerLookingEnter;

    public delegate void playerLookingExit();
    public static playerLookingExit onPlayerLookingExit;

    #region Singleton
    
    private void Awake()
    {
        
        if(_instance != null )
        {
            if (_instance != this)
            {
                Destroy(this.gameObject);
            }
        } else {
            _instance = this;
            _gameObject = this.gameObject;
            DontDestroyOnLoad(_instance);
        }

        canMove = true;
        playerType = selectedPlayerType;

        _Camera = transform.Find("Camera").gameObject;
    }
    
    #endregion


    public Vector3 spwnPosition;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        getView();
        handleLook();
        handleMovement();

    }

    public static void setCanMove(bool state)
    {
        canMove = state;
    }

    void getView()
    {
        if(_Camera != null && playerType != playerTypes.VR)
        {
            RaycastHit Hit;
            var layer = ~(((1 << LayerMask.NameToLayer("Player"))));
            if (Physics.Raycast(_Camera.transform.position, _Camera.transform.forward, out Hit, 50.0f, layer))
            {
                looking = true;
            }
            else
            {
                looking = false;
            }


            if (_looking == true && looking == false)
            {
                _lookedAtObj = lookedAtObj;
                _looking = looking;

                lookedAtObj = null;
                if(onPlayerLookingExit != null)
                {
                    onPlayerLookingExit();
                }
                
            }

            if ((_looking == false && looking == true))
            {
                _lookedAtObj = lookedAtObj;
                _looking = looking;

                lookedAtObj = Hit.collider.gameObject;
                if(onPlayerLookingEnter != null)
                {
                    onPlayerLookingEnter();
                }
                
            }

            if ((_looking == true && looking == true))
            {

                if (lookedAtObj != Hit.collider.gameObject)
                {
                    _lookedAtObj = lookedAtObj;
                    lookedAtObj = Hit.collider.gameObject;
                    if(onPlayerLookingEnter != null)
                    {
                        onPlayerLookingEnter();
                    }
                    
                    if(onPlayerLookingExit != null)
                    {
                        onPlayerLookingExit();
                    }
                    
                }
                if (onPlayerLooking != null)
                {
                    onPlayerLooking();
                }
                
            }
        }
    }

    void handleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (canMove)
        {
            if (!running)
            {
                transform.Translate(getMoveDirection() * walkSpeed * Time.deltaTime, Space.World);
            }
            else
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

        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection -= transform.up;
        }

        if (Input.GetKey(KeyCode.E))
        {
            moveDirection += transform.up;
        }


        return moveDirection.normalized;
    }

    void handleLook()
    {   if(_Camera != null)
        {
            float horizontal = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0, horizontal, 0));
            _Camera.transform.Rotate(-vertical, 0, 0);
        } else
        {
            Debug.Log("No Camera Found");
        }
            
    }
}
