using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldOptions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            if (GameObject.Find("_player") != null)
            {
                GameObject.Find("_player").GetComponent<playerController>().lookLocked = true;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (GameObject.Find("_player") != null)
            {
                GameObject.Find("_player").GetComponent<playerController>().lookLocked = false;
            }
        }
    }
}
