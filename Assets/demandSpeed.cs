using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demandSpeed : MonoBehaviour
{
    public sevenSegDisplay output;

    public float changeTime = 60f;
    private float time = 0f;
    public float maxSpeed = 100f;
    public float minSpeed = 0f;

    public float demandedSpeed;

    Random random = new Random();

    public void generateNewSpeed()
    {
        demandedSpeed = Random.Range(minSpeed, maxSpeed);
        output.value = demandedSpeed;
    }


    private void Start()
    {
        output.value = 10f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > changeTime)
        {
            time = 0f;
            generateNewSpeed();
        }
    }
}
