using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDarrayBehaviour : MonoBehaviour
{
    public class stage
    {
        public List<LEDbehaviour> LEDs;

        public stage()
        {
            LEDs = new List<LEDbehaviour>();
        }
    }

    public int numStages = 0;
    public List<stage> stages = new List<stage>();

    int currentStage;

    public float time;

    public float rate = 5f;

    public enum flowstates { forwards, backwards,stop};
    public flowstates flowstate;


    // Start is called before the first frame update
    void Start()
    {
        buildLEDStages();
        allOff();
    }




    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 1/rate)
        {
            switch (flowstate)
            {
                case flowstates.forwards:
                    flowForward();
                    break;
                case flowstates.backwards:
                    flowBackwards();
                    break;
                case flowstates.stop:
                    flowStop();
                    break;
            }
        }
    }


    public void allOff()
    {
        foreach(stage Stage in stages)
        {
            foreach(LEDbehaviour led in Stage.LEDs)
            {
                led.turnOff();
            }
        }
    }


    public void allOn()
    {
        foreach (stage Stage in stages)
        {
            foreach (LEDbehaviour led in Stage.LEDs)
            {
                led.turnOn();
            }
        }
    }

    public void setStage(int Stage, bool state)
    {
        foreach (LEDbehaviour led in stages[Stage].LEDs)
            led.setState(state);
    }

    /// <summary>
    /// build staging sequence of LEDs
    /// </summary>
    void buildLEDStages()
    {
        string alphnum = null;
        string num, _num = null;
        string alph = null;
        int i = 0;

        foreach (Transform child in transform)
        {

            alphnum = child.name.Substring(Mathf.Max(0, child.name.Length - 4));

            if (char.IsLetter(alphnum.ToCharArray()[alphnum.Length - 1]))
            {
                num = alphnum.Remove(alphnum.Length - 1);
                alph = alphnum.ToCharArray()[alphnum.Length - 1].ToString();
            }
            else
            {
                num = alphnum.Substring(1);
                alph = null;
            }

            if (alph == null)
            {
                stages.Add(new stage());
                stages[i].LEDs.Add(child.GetComponent<LEDbehaviour>());
                i++;
            }
            else
            {
                if (num == _num)
                {
                    stages[i - 1].LEDs.Add(child.GetComponent<LEDbehaviour>());
                }
                else
                {
                    stages.Add(new stage());
                    stages[i].LEDs.Add(child.GetComponent<LEDbehaviour>());
                    i++;
                }
            }

            _num = num;
        }

        numStages = stages.Count;
    }

    public void flowForward()
    {
        time = 0;
        allOff();


        setStage(currentStage, true);
        currentStage++;

        if (currentStage > numStages - 1)
        {
            currentStage = 0;
        }
    }

    public void flowBackwards()
    {
        time = 0;
        allOff();

        setStage(currentStage, true);
        currentStage--;

        if (currentStage < 0 )
        {
            currentStage = numStages - 1;
        }
    }

    public void flowStop()
    {
        allOff();
        time = 0;
    }
}