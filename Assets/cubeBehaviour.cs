using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehaviour : MonoBehaviour
{

    private bool canSpin = false;

    public float spinRate = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinCube();

        if (Input.GetKeyDown(KeyCode.G))
        {
            canSpin = !canSpin;
        }
    }

    void spinCube()
    {
        if (canSpin)
        {
            transform.Rotate(Vector3.up, spinRate * Time.deltaTime);
        }
    }
}
