using UnityEngine;

public class controlRodBehaviour : MonoBehaviour
{
    public float rate = 100/5f;

    public static float position = 0f;
    private float _position = -1;

    Vector3 CROUT, CRIN;

    private bool scramming;

    public void raise()
    {
        if (position < 100 && !scramming){
            position += Time.deltaTime * 100f / 10f;
        }
    }

    public void lower()
    {
        if (position > 0f &&!scramming)
        {
            position -= Time.deltaTime * 100f / 10f;
        }
    }

    public void scram()
    {
        scramming = true;
    }

    private void scrammingBehaviour()
    {
        if (scramming)
        {
            position -= 200f * Time.deltaTime;
        }

        checkLim();

        if (position == 0f){
            scramming = false;
        }
    }


    void setPosition()
    {
        if(_position != position)
        {
            transform.position = Vector3.Lerp(CRIN, CROUT, position / 100f);
            _position = position;
        }
        
    }

    private void Start()
    {
        CRIN = transform.position;
        CROUT = new Vector3(CRIN.x, CRIN.y+ 0.065f, CRIN.z);

    }

    private void Update()
    {
        checkLim();
        scrammingBehaviour();
        setPosition();

    }

    void checkLim()
    {
        if (position < 0f)
        {
            position = 0f;
        }

        if (position > 100f)
        {
            position = 100f;
        }
    }

}
