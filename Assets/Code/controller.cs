using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject output;
    public float turnRate = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, turnRate, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, -turnRate, 0f) * Time.deltaTime);
        }

        output.SendMessage("netUpdateRotation", transform.rotation);
    }
}
