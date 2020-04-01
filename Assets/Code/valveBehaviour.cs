using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valveBehaviour : MonoBehaviour
{

    public float transitTime = 3.0f;

    Color open = new Color(0, 1, 0);
    Color closed = new Color(1, 0, 0);
    Color mid = new Color(1, 1, 0);

    public float position = 100;
    float _position = -1;

    Material mat;

    private void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
    }

    public void closeValve()
    {
        if (position > 0)
        {
            position -= Time.deltaTime * 100f / transitTime;
        }
    }

    public void openValve()
    {
        if (position < 100)
        {
            position += Time.deltaTime * 100f / transitTime;
        }
    }

    public void setColour()
    {
        if (_position != position)
        {
            _position = position;
            if (position <= 50)
            {
                mat.SetColor("_BaseColor", Color.Lerp(closed, mid, position / 50f));
            }
            else
            {
                mat.SetColor("_BaseColor", Color.Lerp(mid, open, (position - 50f) / 50f));
            }
        }
        
    }

    void limitCheck()
    {
        if(position > 100)
        {
            position = 100;
        }

        if(position < 0)
        {
            position = 0;
        }
    }

    private void Update()
    {
        limitCheck();
        setColour();
 
    }


}
