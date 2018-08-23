using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int startTime;
    public GameObject Timer1;
    public GameObject TimerStart;
    public bool isStart = true;
    public GameObject Car;

    private int TimeStart;
    public int time ;

	// Use this for initialization
	void Start () {
        TimeStart = 3;
        InvokeRepeating("StartTime", 0, 1);
        time = startTime;
        InvokeRepeating("Time", TimeStart, 1);
    }

    void StartTime()
    {
        if (TimeStart > 0)
        {
            TimerStart.GetComponent<Text>().text = TimeStart.ToString();
            TimeStart--;
        }
    }

	void Time () {
        TimerStart.GetComponent<Text>().text = "";
        if (time > 0)
        {
            isStart = true;
            Timer1.GetComponent<Text>().text = time.ToString();
            time--;
        }else
        if (time == 0)
        {
            Timer1.GetComponent<Text>().text = "";
            isStart = true;
            if (Car.GetComponent<Points>().isFinish != true)
            {
                isStart = false;
                time = -1;
            }
        }
    }
}
